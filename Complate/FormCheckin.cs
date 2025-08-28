using CloudinaryDotNet.Actions;
using Complate.Data;
using Complate.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Complate
{
    public partial class FormCheckin : Form
    {
        private System.Windows.Forms.Timer pollTimer;
        private bool isRefreshing = false; // flag để tránh task trùng
        private int lastCheckinCount = 0;
        private readonly AppDbContext _context;



        public FormCheckin(AppDbContext context)
        {
            InitializeComponent();
            SetupTimer();
            pbFace.SizeMode = PictureBoxSizeMode.Zoom;
            _context = context;
            LoadCheckinsAsync();

        }
        private void SetupTimer()
        {
            pollTimer = new System.Windows.Forms.Timer();
            pollTimer.Interval = 1000; // 1s
            pollTimer.Tick += async (s, e) =>
            {
                if (!isRefreshing)
                {
                    isRefreshing = true;
                    await RefreshLatestCheckin();
                    isRefreshing = false;
                }
            };
            pollTimer.Start();
        }
        private async Task RefreshLatestCheckin()
        {
            try
            {
                var today = DateTime.Now.Date;
                string beginTime = today.ToString("yyyy-MM-ddT00:00:00");
                string endTime = today.ToString("yyyy-MM-ddT23:59:59");

                var requestJson = new
                {
                    @operator = "SearchControl",
                    info = new
                    {
                        DeviceID = 2565490,
                        BeginTime = beginTime,
                        EndTime = endTime,
                        BeginNO = 0,
                        RequestCount = 100,
                        PersonType = 0
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");
                var response = await HttpClientHelper.Client.PostAsync("/action/SearchControl", content);

                if (!response.IsSuccessStatusCode)
                {
                    lblWarning.Invoke(() => lblWarning.Text = "API trả về lỗi HTTP!");
                    return;
                }

                string respStr = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(respStr);

                if (!jsonDoc.RootElement.TryGetProperty("info", out var info) ||
                    !info.TryGetProperty("SearchInfo", out var searchInfo)) return;

                int currentCount = searchInfo.GetArrayLength();
                if (currentCount <= lastCheckinCount) return;
                lastCheckinCount = currentCount;

                // Lấy checkin mới nhất VerifyStatus = 1
                var latest = searchInfo.EnumerateArray()
                    .Where(x => x.TryGetProperty("VerifyStatus", out var v) && v.GetInt32() == 1)
                    .OrderByDescending(x =>
                    {
                        if (x.TryGetProperty("Time", out var t) && DateTime.TryParse(t.GetString(), out var dt))
                            return dt;
                        return DateTime.MinValue;
                    })
                    .FirstOrDefault();

                if (latest.ValueKind == JsonValueKind.Undefined) return;

                string idCard = latest.TryGetProperty("IdCard", out var idProp) ? idProp.GetString() : null;
                string name = latest.TryGetProperty("Name", out var nameProp) ? nameProp.GetString() : "";
                string time = latest.TryGetProperty("Time", out var timeProp) ? timeProp.GetString() : "";

                // Cập nhật UI
                txtName.Invoke(() => txtName.Text = name);
                txtTime.Invoke(() => txtTime.Text = time);

                if (string.IsNullOrEmpty(idCard))
                {
                    pbFace.Invoke(() => pbFace.Image = null);
                    return;
                }

                // Lấy user trong DB
                var person = _context.Persons.FirstOrDefault(p => p.IdCard == idCard);
                if (person == null)
                {
                    pbFace.Invoke(() => pbFace.Image = null);
                    lblWarning.Invoke(() => lblWarning.Text = "Không tìm thấy người trong DB!");
                    return;
                }

                // trường hợp nếu có base
                if (!string.IsNullOrEmpty(person.PhotoData))
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(person.PhotoData);
                        using var ms = new MemoryStream(imgBytes);
                        var bmp = new Bitmap(ms);

                        pbFace.Invoke(() =>
                        {
                            pbFace.Image?.Dispose();
                            pbFace.Image = new Bitmap(bmp);
                            pbFace.SizeMode = PictureBoxSizeMode.Zoom;
                        });

                        txt_idcard.Invoke(() => txt_idcard.Text = idCard);
                        lblWarning.Invoke(() => lblWarning.Text = "");
                    }
                    catch (Exception ex)
                    {
                        pbFace.Invoke(() => pbFace.Image = null);
                        lblWarning.Invoke(() => lblWarning.Text = $"Không thể load ảnh từ Base64: {ex.Message}");
                    }
                }
                // Nếu không có base64 thì fallback về URL
                else if (!string.IsNullOrEmpty(person.PhotoUrl))
                {
                    if (!Uri.TryCreate(person.PhotoUrl, UriKind.Absolute, out var uri))
                    {
                        pbFace.Invoke(() => pbFace.Image = null);
                        lblWarning.Invoke(() => lblWarning.Text = "URL ảnh không hợp lệ!");
                        return;
                    }

                    try
                    {
                        using var wc = new System.Net.WebClient();
                        var imgBytes = await wc.DownloadDataTaskAsync(uri);
                        using var ms = new MemoryStream(imgBytes);
                        var bmp = new Bitmap(ms);

                        pbFace.Invoke(() =>
                        {
                            pbFace.Image?.Dispose();
                            pbFace.Image = new Bitmap(bmp);
                            pbFace.SizeMode = PictureBoxSizeMode.Zoom;
                        });

                        txt_idcard.Invoke(() => txt_idcard.Text = idCard);
                        lblWarning.Invoke(() => lblWarning.Text = "");
                    }
                    catch (Exception ex)
                    {
                        pbFace.Invoke(() => pbFace.Image = null);
                        lblWarning.Invoke(() => lblWarning.Text = $"Không tải được ảnh từ URL: {ex.Message}");
                    }
                }
                else
                {
                    pbFace.Invoke(() => pbFace.Image = null);
                    lblWarning.Invoke(() => lblWarning.Text = "Không tìm thấy ảnh trong DB!");
                }

                // Cập nhật lại lịch sử checkin
                await LoadCheckinsAsync();
            }
            catch (Exception ex)
            {
            }
        }



        public enum CheckinRange
        {
            Day,
            Week,
            Month
        }

        private async Task LoadCheckinsAsync(CheckinRange range = CheckinRange.Day)
        {
            try
            {
                DateTime end = DateTime.Now;
                DateTime start = range switch
                {
                    CheckinRange.Day => end.Date,
                    CheckinRange.Week => end.Date.AddDays(-7),
                    CheckinRange.Month => end.Date.AddMonths(-1),
                    _ => end.Date
                };

                string beginTime = start.ToString("yyyy-MM-ddT00:00:00");
                string endTime = end.ToString("yyyy-MM-ddT23:59:59");

                var requestJson = new
                {
                    @operator = "SearchControl",
                    info = new
                    {
                        DeviceID = 2565490,
                        BeginTime = beginTime,
                        EndTime = endTime,
                        BeginNO = 0,
                        RequestCount = 100,
                        PersonType = 0
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");
                var response = await HttpClientHelper.Client.PostAsync("/action/SearchControl", content);
                string respStr = await response.Content.ReadAsStringAsync();

                var jsonDoc = JsonDocument.Parse(respStr);
                var info = jsonDoc.RootElement.GetProperty("info");

                if (!info.TryGetProperty("SearchInfo", out var searchInfo))
                {
                    dtg_historycheck.DataSource = null;
                    return;
                }

                var checkins = searchInfo.EnumerateArray()
                    .Select(x =>
                    {
                        string idCard = x.GetProperty("IdCard").GetString();
                        var person = _context.Persons.FirstOrDefault(p => p.IdCard == idCard);

                        // Nếu có Base64 trong DB thì ưu tiên decode ra ảnh
                        Image photo = null;
                        if (person != null && !string.IsNullOrEmpty(person.PhotoData))
                        {
                            try
                            {
                                byte[] imgBytes = Convert.FromBase64String(person.PhotoData);
                                using var ms = new MemoryStream(imgBytes);
                                photo = new Bitmap(ms);
                            }
                            catch { photo = null; }
                        }

                        return new
                        {
                            LibID = x.GetProperty("LibID").GetInt32(),
                            Name = x.GetProperty("Name").GetString(),
                            IdCard = idCard,
                            Time = x.GetProperty("Time").GetString(),
                            VerifyStatus = x.GetProperty("VerifyStatus").GetInt32(),
                            Photo = photo
                        };
                    })
                    .OrderByDescending(x => DateTime.Parse(x.Time))
                    .ToList();

                dtg_historycheck.DataSource = checkins;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load checkins: " + ex.Message);
            }
        }
        private async Task SaveCheckinToDb(string idCard, string name, DateTime time, int libId, int verifyStatus, string base64Photo)
        {
            try
            {
                // Kiểm tra xem checkin đã tồn tại chưa để tránh duplicate
                bool exists = _context.Checkins.Any(c => c.IdCard == idCard && c.Time == time && c.LibID == libId);
                if (exists) return;

                var checkin = new Checkin
                {
                    IdCard = idCard,
                    Name = name,
                    Time = time,
                    LibID = libId,
                    VerifyStatus = verifyStatus,
                    PhotoData = string.IsNullOrEmpty(base64Photo) ? null : Convert.FromBase64String(base64Photo)
                };

                _context.Checkins.Add(checkin);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                lblWarning.Invoke(() => lblWarning.Text = $"Lỗi lưu checkin: {ex.Message}");
            }
        }


        private async void btn_day_Click(object sender, EventArgs e)
        {
            await LoadCheckinsAsync(CheckinRange.Day);
        }

        private async void btn_month_Click(object sender, EventArgs e)
        {
            await LoadCheckinsAsync(CheckinRange.Month);
        }

        private async void btn_7day_Click(object sender, EventArgs e)
        {
            await LoadCheckinsAsync(CheckinRange.Week);
        }
        private void dtg_historycheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dtg_historycheck.Rows[e.RowIndex];
            txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
            txt_idcard.Text = row.Cells["IdCard"].Value?.ToString() ?? "";
            txtTime.Text = row.Cells["Time"].Value?.ToString() ?? "";

            var photo = row.Cells["Photo"].Value as Image;
            pbFace.Image?.Dispose();
            pbFace.Image = photo != null ? new Bitmap(photo) : null;
            pbFace.SizeMode = PictureBoxSizeMode.Zoom;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
        }
        private void dgvCheckin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCheckin_Load(object sender, EventArgs e)
        {

        }

        private void dtg_historycheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
