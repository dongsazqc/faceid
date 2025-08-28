// WebServer.cs
using Complate.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class WebServer
{
    private readonly HttpListener _listener;
    private CancellationTokenSource _cts;
    private PictureBox _liveView;

    public WebServer(string urlPrefix, PictureBox liveView)
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add(urlPrefix);
        _liveView = liveView;
    }

    public void Start()
    {
        if (_listener.IsListening) return;

        _cts = new CancellationTokenSource();
        _listener.Start();
        Console.WriteLine("✅ WebServer started at " + string.Join(", ", _listener.Prefixes));

        Task.Run(() => HandleRequests(_cts.Token));
    }

    public void Stop()
    {
        if (!_listener.IsListening) return;

        _cts.Cancel();
        _listener.Stop();
        Console.WriteLine("🛑 WebServer stopped.");
    }

    private async Task HandleRequests(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                var ctx = await _listener.GetContextAsync();
                var request = ctx.Request;

                string body = "";
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    body = await reader.ReadToEndAsync();
                }

                Console.WriteLine($"📩 Received {request.HttpMethod} {request.Url.AbsolutePath}");

                if (request.Url.AbsolutePath == "/Subscribe/Snap")
                {
                    // Đây là ảnh face push về
                    try
                    {
                        var person = JsonSerializer.Deserialize<Person>(body);

                        if (person != null && !string.IsNullOrEmpty(person.PhotoData))
                        {
                            byte[] imgBytes = Convert.FromBase64String(person.PhotoData);
                            string fileName = $"face_{person.PersonUUID}_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                            await File.WriteAllBytesAsync(fileName, imgBytes);

                            Console.WriteLine($"💾 Saved snapshot: {fileName}");

                            // Cập nhật live view trên form
                            if (_liveView != null)
                            {
                                _liveView.Invoke((MethodInvoker)(() =>
                                {
                                    using var ms = new MemoryStream(imgBytes);
                                    _liveView.Image?.Dispose();
                                    _liveView.Image = System.Drawing.Image.FromStream(ms);
                                }));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Error parsing Person JSON: {ex.Message}");
                    }
                }
                else
                {
                    // Confirm subscribe / heartbeat
                    Console.WriteLine($"🔹 Other payload: {body}");
                    string logFile = $"log_{DateTime.Now:yyyyMMdd}.txt";
                    await File.AppendAllTextAsync(logFile, $"[{DateTime.Now}] {body}\n");
                }

                // Trả response OK
                byte[] buffer = Encoding.UTF8.GetBytes("OK");
                ctx.Response.ContentType = "text/plain";
                ctx.Response.ContentLength64 = buffer.Length;
                await ctx.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                ctx.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                if (_listener.IsListening)
                    Console.WriteLine("⚠️ " + ex.Message);
            }
        }
    }
}
