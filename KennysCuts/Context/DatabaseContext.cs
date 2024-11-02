using KennysCuts.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KennysCuts.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Services> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Barber> Barber { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, "database.db");
            optionbuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
