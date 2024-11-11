using KennysCuts.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KennysCuts.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        private IWebHostEnvironment _environment;
        public DbSet<Services> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Barber> Barber { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment enviornment) : base(options)
        {
            _environment = enviornment;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            optionbuilder.UseSqlite($"Data Source={folder}/KennysCuts.db");
        }
    }
}
