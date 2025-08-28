using Complate;
using Complate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        services.AddDbContext<AppDbContext>(options =>
      options.UseMySql(
          "Server=localhost;Database=FaceDeviceDB;User=root;Password=Sazqc@123;",
          new MySqlServerVersion(new Version(8, 0, 43)) 
      ));
        // Đăng ký FormUser để DI lấy ra được
        services.AddTransient<FormUser>();
        services.AddTransient<FormMain>();
        services.AddTransient<FormIp>();


        var serviceProvider = services.BuildServiceProvider();

        Application.Run(serviceProvider.GetRequiredService<FormMain>());
    }
}
