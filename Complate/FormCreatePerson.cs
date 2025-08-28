using Complate.Data;
using Complate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Complate.FormUser;

namespace Complate
{
    public partial class FormCreatePerson : Form
    {
        private readonly AppDbContext _context;
        private readonly int fixedDeviceID = 2565490;
        private BindingSource bs = new BindingSource();

        public FormCreatePerson(AppDbContext context)
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
                        CardType = 0,
                        Address = txt_Address.Text.Trim(),
                        IdCard = idCard,
                        Birthday = dtp_Birthday.Value.ToString("yyyy-MM-dd"),
                        Telnum = txt_Telnum.Text.Trim(),
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
                        Address = txt_Address.Text.Trim(),
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

        }
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

            } while (_context.Persons.Any(p => p.IdCard == id));
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


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void cbx_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Telnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Imurl_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_imgdata_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            CaptureAndUploadAsync();
        }

        private void btn_createuser_Click(object sender, EventArgs e)
        {
            AddPersonAsync();
        }
    }
}
