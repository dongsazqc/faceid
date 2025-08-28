using Complate.Models;
using Microsoft.EntityFrameworkCore;

namespace Complate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Checkin> Checkins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "Server=localhost;Database=FaceDeviceDB;User=root;Password=Sazqc@123;",
                    new MySqlServerVersion(new Version(8, 0, 43))
                );
            }
        }
    }
}
