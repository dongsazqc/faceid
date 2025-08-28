using ClosedXML.Excel;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Complate.Data;
using Complate.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;


namespace Complate
{
    public partial class FormUser : Form
    {
        private readonly AppDbContext _context;
        private readonly int fixedDeviceID = 2565490;
        private BindingSource bs = new BindingSource();

        public FormUser(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            cbx_Gender.Items.Clear();
            cbx_Gender.Items.Add(new ComboBoxItem { Text = "Nữ", Value = 1 });
            cbx_Gender.Items.Add(new ComboBoxItem { Text = "Nam", Value = 2 });
            cbx_Gender.DisplayMember = "Text";
            cbx_Gender.ValueMember = "Value";
            cbx_Gender.SelectedIndex = 1;


        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }



        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadPersonListAsync();
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditPersonAsync();
        }
        private async Task EditPersonAsync()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn người để chỉnh sửa!");
                return;
            }

            // Lấy thông tin người đang chọn
            string customizeID = dataGridView1.CurrentRow.Cells["CustomizeID"].Value?.ToString();
            if (string.IsNullOrEmpty(customizeID))
            {
                MessageBox.Show("Không tìm thấy CustomizeID!");
                return;
            }

            var person = _context.Persons.FirstOrDefault(p => p.CustomizeID == customizeID);
            if (person == null)
            {
                MessageBox.Show("Không tìm thấy người trong DB!");
                return;
            }

            // Lấy dữ liệu mới từ các textbox / combobox
            string newName = txt_Name.Text.Trim();
            int newGender = (cbx_Gender.SelectedItem as ComboBoxItem)?.Value ?? 2;
            string newTel = txt_Telnum.Text.Trim();
            DateTime newBirthday = dtp_Birthday.Value;
            string newImageUrl = txt_Imurl.Text.Trim();
            string newBase64Data = txt_imgdata.Text.Trim();
            string newaddress = txt_Address.Text.Trim();
            try
            {
                // Payload gửi API
                var payload = new
                {
                    @operator = "EditPerson",
                    info = new
                    {
                        DeviceID = 2565490,
                        IdType = 0,
                        CustomizeID = customizeID,
                        PersonType = 0,
                        Name = newName,
                        Gender = newGender,
                        Birthday = newBirthday.ToString("yyyy-MM-dd"),
                        Telnum = newTel,
                        picURI = newImageUrl,
                        Address = newaddress
                    }
                };

                var client = HttpClientHelper.Client;
                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/action/EditPerson", content);
                string result = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(result);

                if (json != null && json.code == 200 && json.info.Result == "Ok")
                {
                    // Update DB local
                    person.Name = newName;
                    person.Gender = newGender;
                    person.Telnum = newTel;
                    person.Birthday = newBirthday;
                    person.PhotoUrl = newImageUrl;
                    if (!string.IsNullOrEmpty(newBase64Data))
                        person.PhotoData = newBase64Data;

                    await _context.SaveChangesAsync();

                    MessageBox.Show("Cập nhật người dùng thành công!");
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thất bại: " + result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chỉnh sửa: " + ex.Message);
            }

          
            await LoadPersonListAsync();
        }
        private int gender = 2; // default Nam
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbx_Gender.SelectedItem is ComboBoxItem selected)
            {
                gender = selected.Value;
                Console.WriteLine("Giới tính được chọn: " + gender);
            }
        }
        private async Task LoadPersonListAsync()
        {
            try
            {
                var client = HttpClientHelper.Client;

                var payload = new
                {
                    @operator = "SearchPersonList",
                    info = new
                    {
                        DeviceID = fixedDeviceID,
                        BeginNo = 0,
                        Count = 50
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/action/SearchPersonList", content);
                var result = await response.Content.ReadAsStringAsync();

                dynamic json = JsonConvert.DeserializeObject(result);

                if (json?.info?.List != null)
                {
                    // Chỉ lấy các trường cần thiết
                    var persons = ((JArray)json.info.List)
                        .Select(p => new
                        {
                            CustomizeID = p["CustomizeID"]?.ToString(),
                            PersonUUID = p["PersonUUID"]?.ToString(),
                            IdCard = p["IdCard"]?.ToString(),
                            Name = p["Name"]?.ToString(),
                            Telnum = p["Telnum"]?.ToString(),
                            Gender = p["Gender"]?.ToObject<int?>() == 2 ? "Nam" : "Nữ",
                            Birthday = p["Birthday"]?.ToObject<DateTime?>(),
                            Address = p["Address"]?.ToString(),
                        })
                        .ToList();

                    bs.DataSource = persons;
                    dataGridView1.DataSource = bs;
                }
                else
                {
                    MessageBox.Show("Không có ai trong danh sách ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            // Lấy các thông tin cơ bản
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value?.ToString() ?? "";
            txt_Telnum.Text = dataGridView1.CurrentRow.Cells["Telnum"].Value?.ToString() ?? "";
            txt_Address.Text = dataGridView1.CurrentRow.Cells["Address"].Value?.ToString() ?? "";
            dtp_Birthday.Value = dataGridView1.CurrentRow.Cells["Birthday"].Value != null
                ? Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Birthday"].Value)
                : DateTime.Now;

            // Gender
            string genderVal = dataGridView1.CurrentRow.Cells["Gender"].Value?.ToString();
            cbx_Gender.SelectedIndex = (genderVal == "Nam") ? 1 : 0;

            // Lấy IdCard hiện tại
            string idCard = dataGridView1.CurrentRow.Cells["IdCard"].Value?.ToString();
            if (string.IsNullOrEmpty(idCard)) return;

            // Tìm trong DB local
            var person = _context.Persons.FirstOrDefault(p => p.IdCard == idCard);
            if (person != null)
            {
                // Hiển thị ảnh từ URL hoặc Base64
                if (!string.IsNullOrEmpty(person.PhotoUrl))
                {
                    txt_Imurl.Text = person.PhotoUrl;
                }
                if (!string.IsNullOrEmpty(person.PhotoData))
                {
                    txt_imgdata.Text = person.PhotoData;

                    // Chuyển Base64 sang ảnh và show lên PictureBox
                    try
                    {
                        byte[] bytes = Convert.FromBase64String(person.PhotoData);
                        using (var ms = new MemoryStream(bytes))
                        {
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = Image.FromStream(ms);
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch
                    {
                        pictureBox1.Image = null;
                    }
                }
            }
        }
        private async void btn_Capture_Click(object sender, EventArgs e)
        {
        }
        private async void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn người để xóa!");
                return;
            }

            // Lấy CustomizeID từ row hiện tại
            string customizeID = dataGridView1.CurrentRow.Cells["CustomizeID"].Value?.ToString();
            if (string.IsNullOrEmpty(customizeID))
            {
                MessageBox.Show("Không tìm thấy CustomizeID để xóa!");
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa người có CustomizeID = {customizeID}?",
                                          "Xác nhận",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var client = HttpClientHelper.Client;

                // Payload xóa trên thiết bị (CustomizeID phải là mảng int)
                var payload = new
                {
                    @operator = "DeletePerson",
                    info = new
                    {
                        DeviceID = 2565490,
                        TotalNum = 1,
                        IdType = 0, // 0 = CustomizeID
                        CustomizeID = new int[] { int.Parse(customizeID) }
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload),
                                                Encoding.UTF8,
                                                "application/json");

                var response = await client.PostAsync("/action/DeletePerson", content);
                string result = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(result);

                if (json != null && json.code == 200 && json.info.Result == "Ok")
                {
                    // Xóa trong DB local luôn
                    var person = _context.Persons.FirstOrDefault(p => p.CustomizeID == customizeID);
                    if (person != null)
                    {
                        _context.Persons.Remove(person);
                        await _context.SaveChangesAsync();
                    }

                    MessageBox.Show("Xóa thành công trên thiết bị và MySQL!");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại trên thiết bị: " + result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }

            // Refresh lại danh sách
            await LoadPersonListAsync();
        }

        private void MakeButtonRound(Button btn)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = Math.Min(btn.Width, btn.Height);
            path.AddEllipse(0, 0, diameter, diameter);
            btn.Region = new Region(path);
        }
        private void ExportUserListToExcel()
        {
            try
            {
                if (bs.DataSource == null)
                {
                    MessageBox.Show("No users to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var users = (bs.DataSource as IEnumerable<dynamic>).ToList();

                // Lấy thư mục Documents của user hiện tại
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = $"UserList_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string fullPath = Path.Combine(documentsPath, fileName);

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Users");

                    // Header
                    worksheet.Cell(1, 1).Value = "CustomizeID";
                    worksheet.Cell(1, 2).Value = "PersonUUID";
                    worksheet.Cell(1, 3).Value = "IdCard";
                    worksheet.Cell(1, 4).Value = "Name";
                    worksheet.Cell(1, 5).Value = "Gender";
                    worksheet.Cell(1, 6).Value = "Birthday";
                    worksheet.Cell(1, 7).Value = "Address";

                    // Data
                    for (int i = 0; i < users.Count; i++)
                    {
                        var u = users[i];
                        int row = i + 2;
                        worksheet.Cell(row, 1).Value = u.CustomizeID ?? "";
                        worksheet.Cell(row, 2).Value = u.PersonUUID ?? "";
                        worksheet.Cell(row, 3).Value = u.IdCard ?? "";
                        worksheet.Cell(row, 4).Value = u.Name ?? "";

                        // Gender là "Nam"/"Nữ" rồi, không cần parse int
                        string genderStr = u.Gender?.ToString() ?? "";
                        worksheet.Cell(row, 5).Value = genderStr;

                        // Birthday format
                        worksheet.Cell(row, 6).Value = u.Birthday != null
                            ? Convert.ToDateTime(u.Birthday).ToString("yyyy-MM-dd")
                            : "";

                        // Address
                        worksheet.Cell(row, 7).Value = u.Address?.ToString() ?? "";
                    }

                    workbook.SaveAs(fullPath);
                }

                MessageBox.Show($"User list exported to Excel successfully!\nPath: {fullPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to export Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];


            txt_Name.Text = row.Cells["Name"].Value?.ToString() ?? "";
            txt_Telnum.Text = row.Cells["Telnum"].Value?.ToString() ?? "";
            dtp_Birthday.Value = row.Cells["Birthday"].Value != null
                ? (DateTime)row.Cells["Birthday"].Value
                : DateTime.Now;





            var person = _context.Persons.FirstOrDefault(p => p.CustomizeID == row.Cells["CustomizeID"].Value.ToString());
            if (person != null)
            {
                if (!string.IsNullOrEmpty(person.PhotoData))
                {
                    byte[] imgBytes = Convert.FromBase64String(person.PhotoData);
                    using var ms = new MemoryStream(imgBytes);
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = new Bitmap(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (!string.IsNullOrEmpty(person.PhotoUrl))
                {
                    try
                    {
                        var wc = new System.Net.WebClient();
                        var imgBytes = wc.DownloadData(person.PhotoUrl);
                        using var ms = new MemoryStream(imgBytes);
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = new Bitmap(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch { pictureBox1.Image = null; }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }
        private void btn_create_Click(object sender, EventArgs e)
        {
            using (var createForm = new FormCreatePerson(_context))
            {
                createForm.ShowDialog();
            }


            _ = LoadPersonListAsync();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            ExportUserListToExcel();
        }
        private void txt_Imurl_TextChanged(object sender, EventArgs e)
        {
            txt_Imurl.MaxLength = 0;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_DeviceId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_IdCard_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_Telnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Native_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {


        }

       

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void txt_PersonType_TextChanged(object sender, EventArgs e)
        {

        }

      

    }
}
