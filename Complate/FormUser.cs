using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Complate.Data;
using Complate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            cbx_Gender.SelectedIndex = 1; // Mặc định Nam
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text; // hiển thị ra UI
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadPersonListAsync();
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddPersonAsync();
        }
        private async Task AddPersonAsync()
        {
            try
            {
                string imageUrl = txt_Imurl.Text.Trim();
                string base64Data = txt_imgdata.Text.Trim(); // Lấy Base64 trực tiếp từ txtImgData

                if (string.IsNullOrEmpty(imageUrl) || string.IsNullOrEmpty(base64Data))
                {
                    MessageBox.Show("Chưa có ảnh để AddPerson!");
                    return;
                }

                int gender = 1; // 1: nữ, 2: nam
                string customizeID = GenerateUniqueCustomizeID();
                string personUUID = GenerateUniquePersonUUID();
                string idCard = GenerateUniqueCustomizeID();
                // Tạo payload gửi API
                var payload = new
                {
                    @operator = "EditPersonsNew",
                    DeviceID = 2565490,
                    IdType = 0,
                    Total = 1,
                    info = new[]
                    {
                new
                {
                    @operator = "AddPerson",
                    info = new
                    {
                        DeviceID = 2565490,
                        CustomizeID = customizeID,
                        PersonUUID = personUUID,
                        PersonType = 0,
                        Name = txt_Name.Text.Trim(),
                        Gender = gender,
                        Nation = 0,
                        CardType = 0,
                        IdCard = idCard,
                        Birthday = dtp_Birthday.Value.ToString("yyyy-MM-dd"),
                        Telnum = txt_Telnum.Text.Trim(),
                        Native = txt_Native.Text.Trim(),
                        Address = txt_Address.Text.Trim(),
                        Notes = txt_Notes.Text.Trim(),
                        picURI = imageUrl,
                    }
                }
            }
                };

                var client = HttpClientHelper.Client;
                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/action/EditPersonsNew", content);
                var result = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(result);

                if (json != null && json.code == 200 && json.info.EditsSucNum == 1)
                {
                    var newPerson = new Person
                    {
                        DeviceID = 2565490,
                        Name = txt_Name.Text.Trim(),
                        Gender = gender,
                        IdCard = idCard,
                        Birthday = dtp_Birthday.Value,
                        Telnum = txt_Telnum.Text.Trim(),
                        Native = txt_Native.Text.Trim(),
                        Address = txt_Address.Text.Trim(),
                        Notes = txt_Notes.Text.Trim(),
                        PhotoUrl = imageUrl,
                        PhotoData = base64Data, // Lấy trực tiếp từ txtImgData
                        CustomizeID = customizeID,
                        PersonUUID = personUUID
                    };

                    _context.Persons.Add(newPerson);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("AddPerson thành công và lưu vào MySQL!");
                }
                else
                {
                    MessageBox.Show("AddPerson thất bại: " + result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi AddPerson: " + ex.Message);
            }

            await LoadPersonListAsync();
        }

        // ------------------- Helper sinh ID không trùng -------------------
        private string GenerateUniqueCustomizeID()
        {
            Random rand = new Random();
            string id;
            do
            {
                id = rand.Next(100000, 999999).ToString(); // 6 chữ số
            } while (_context.Persons.Any(p => p.CustomizeID == id));
            return id;
        }

        private string GenerateUniquePersonUUID()
        {
            Random rand = new Random();
            string id;
            do
            {
                id = rand.Next(10000000, 99999999).ToString(); // 8 chữ số
            } while (_context.Persons.Any(p => p.PersonUUID == id));
            return id;
        }

        private string randumidcard()
        {
            Random rand = new Random();
            string id;
            do
            {
                id = rand.Next(100000000, 999999999).ToString(); // 9 chữ số
                
            }while(_context.Persons.Any(p => p.IdCard == id));
            return id;
        }
        private byte[] capturedImageBytes = null; // lưu tạm để AddPerson dùng

        private async Task CaptureAndUploadAsync()
        {
            try
            {
                var client = HttpClientHelper.Client;
                var payload = new
                {
                    @operator = "FrontalFaceSnap",
                    info = new { DeviceID = 2565490, Overall = 1 }
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/action/FrontalFaceSnap", content);
                var result = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(result);

                if (json == null || json.code != 200 || json.info.Result != "Ok")
                {
                    MessageBox.Show("Không lấy được ảnh: " + result);
                    return;
                }

                // Convert base64 từ API sang byte[]
                string base64Img = json.FacePic.ToString();
                if (base64Img.StartsWith("data:image"))
                {
                    int commaIndex = base64Img.IndexOf(",");
                    base64Img = base64Img.Substring(commaIndex + 1);
                }
                capturedImageBytes = Convert.FromBase64String(base64Img);

                // Hiển thị lên PictureBox
                using (var ms = new MemoryStream(capturedImageBytes))
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromStream(ms);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                // Upload lên Cloud
                string fileName = $"face_{DateTime.Now.Ticks}.jpg";
                string url = await Task.Run(() => CloudinaryHelper.UploadImage(capturedImageBytes, fileName));
                txt_Imurl.Text = url;

                // Đồng thời lưu base64 vào txtImgData
                txt_imgdata.Text = Convert.ToBase64String(capturedImageBytes);

                MessageBox.Show("Upload Cloudinary xong! URL: " + url + "\nBase64 đã lưu vào txtImgData");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chụp ảnh: " + ex.Message);
            }
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
                            Gender = p["Gender"]?.ToObject<int?>(),
                            Birthday = p["Birthday"]?.ToObject<DateTime?>(),
                            Nation = p["Nation"]?.ToObject<int?>()
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

        }
        private async void btn_Capture_Click(object sender, EventArgs e)
        {
            CaptureAndUploadAsync();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void txt_Imurl_TextChanged(object sender, EventArgs e)
        {
            txt_Imurl.MaxLength = 0;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
