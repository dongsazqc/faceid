using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

public static class HttpClientHelper
{
    private static HttpClient _client;

    public static HttpClient Client
    {
        get
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri("http://192.168.0.107"); // IP máy chấm công

                var byteArray = Encoding.ASCII.GetBytes("admin:112233");
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }
            return _client;
        }
    }
}
