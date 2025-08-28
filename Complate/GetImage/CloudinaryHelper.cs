using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public static class CloudinaryHelper
{
    private static Cloudinary cloudinary;

    static CloudinaryHelper()
    {
        var account = new Account(
            "daxjjxaj0",
            "221268817326816",
            "H5M6nJqffwcysYrANshZvYs1SbM"
        );
        cloudinary = new Cloudinary(account);
    }

    // Upload image và trả về URL
    public static string UploadImage(byte[] bytes, string fileName)
    {
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(fileName, new MemoryStream(bytes)),
            Folder = "face_snapshots",
            Overwrite = true
        };

        var uploadResult = cloudinary.Upload(uploadParams);
        if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            return uploadResult.SecureUrl.ToString();
        else
            throw new Exception(uploadResult.Error?.Message);
    }

    // Lấy URL ảnh theo publicId (hoặc tên file)
    public static string GetImageUrl(string publicId)
    {
        var url = cloudinary.Api.UrlImgUp.BuildUrl(publicId);
        return url;
    }

    // <-- Hàm này là fix lỗi của mày -->
    public static async Task<string> GetCaptureImageUrlAsync(int deviceId, int libId)
    {
        // 1. Gọi API GetImage hoặc SearchCapture để lấy Base64 ảnh
        var payload = new
        {
            @operator = "GetImage",
            info = new
            {
                dwfiletype = 2, // ảnh realtime
                dwfileindex = libId,
                dwfilepos = 0
            }
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(payload),
            Encoding.UTF8,
            "application/json"
        );

        var response = await HttpClientHelper.Client.PostAsync("/action/GetImage", content);
        var respStr = await response.Content.ReadAsStringAsync();
        dynamic json = JsonConvert.DeserializeObject(respStr);

        if (json != null && json.code == 200 && json.info.Pic != null)
        {
            string base64Img = json.info.Pic.ToString();
            if (base64Img.StartsWith("data:image"))
            {
                int comma = base64Img.IndexOf(',');
                base64Img = base64Img.Substring(comma + 1);
            }
            byte[] imgBytes = Convert.FromBase64String(base64Img);

            // 2. Upload Cloudinary
            string fileName = $"capture_{deviceId}_{libId}.jpg";
            return UploadImage(imgBytes, fileName);
        }

        return null;
    }
}

