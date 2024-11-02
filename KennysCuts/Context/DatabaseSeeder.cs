using KennysCuts.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace KennysCuts.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Services.Any())
            {
                var services = GetServices();
                _context.Services.AddRange(services);
                await _context!.SaveChangesAsync();
            }


            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customers"));

                var adminEmail = "admin@barbers.com";
                var adminPassword = "Kenny1111!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "Kenny",
                    Surname = "Phoenix"
                };

                await _userManager.CreateAsync(admin, adminPassword);
               await _userManager.AddToRoleAsync(admin, "Admin");

            }

        }

        private List<Services> GetServices()
        {
            return
            [
            new Services { Id = 1, Name = "Classic Taper", Description = "A timeless haircut where the hair gradually shortens from the top to the sides, creating a clean and professional look.", Price = 30, Duration = 30 },
            new Services { Id = 2, Name = "Undercut", Description = "The undercut features long hair on top and shaved or closely trimmed sides, offering a bold and modern contrast.", Price = 40, Duration = 45 },
             new Services { Id = 3, Name = "Crew Cut", Description = "A sharp, short style that keeps the hair close to the scalp, making it perfect for a neat, low-maintenance look.", Price = 25, Duration = 20 },
             new Services { Id = 4, Name = "Buzz Cut", Description = "An all-around short cut done with clippers, this military-inspired style is ideal for those looking for a simple, clean look.", Price = 20, Duration = 15 },
             new Services { Id = 5, Name = "Fade Cut", Description = "A fade gradually blends the hair from long at the top to very short on the sides, offering a sleek and polished finish.", Price = 35, Duration = 40 },
             new Services { Id = 6, Name = "Pompadour", Description = "This retro hairstyle is characterized by longer hair styled high above the forehead, with shorter sides for a voluminous look.", Price = 50, Duration = 60 },
             new Services { Id = 7, Name = "French Crop", Description = "A textured style featuring short hair with a blunt fringe, ideal for those who want a stylish, easy-to-maintain cut.", Price = 30, Duration = 30 },
             new Services { Id = 8, Name = "Caesar Cut", Description = "Inspired by Julius Caesar, this haircut has short, horizontally cut bangs and evenly trimmed hair all around.", Price = 30, Duration = 30 },
             new Services { Id = 9, Name = "Quiff", Description = "The quiff combines volume with a stylish back-swept top, making it a versatile choice for both casual and formal looks.", Price = 45, Duration = 50 },
             new Services { Id = 10, Name = "High and Tight", Description = "A military-style cut with very short sides and slightly longer hair on top, offering a sharp and clean look.", Price = 25, Duration = 25 },
             new Services { Id = 11, Name = "Textured Fringe", Description = "This haircut combines medium-length textured hair with a fringe, creating a casual, relaxed style.", Price = 35, Duration = 40 }
            ];
        }

        private List<Barber> GetBarbers()
        {
            return
            [
                new Barber {Id = 1, Name = "Kenny", Availability = "Yes"},
                new Barber {Id = 2, Name = "George", Availability = "Yes"},
                new Barber {Id = 3, Name = "Jimmy", Availability = "Yes"},

            ];
        }
    }
}