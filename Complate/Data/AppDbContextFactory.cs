using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Complate.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Database=FaceDeviceDB;User=root;Password=Sazqc@123;",
                new MySqlServerVersion(new Version(8, 0, 43))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
