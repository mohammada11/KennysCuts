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
            new Services { Id = 1, Description = "Basic Haircut", Price = 15, Duration = 30 },
            new Services { Id = 2, Description = "Buzz Cut", Price = 10, Duration = 20 },
            new Services { Id = 3, Description = "Layered Cut", Price = 25, Duration = 45 },
            new Services { Id = 4, Description = "Bob Cut", Price = 16, Duration = 40 },
            new Services { Id = 5, Description = "Shampoo and Cut", Price = 22, Duration = 50 },
            new Services { Id = 6, Description = "Men's Haircut", Price = 18, Duration = 35 },
            new Services { Id = 7, Description = "Skin Fade", Price = 18, Duration = 30 },
            new Services { Id = 8, Description = "Children's Haircut", Price = 12, Duration = 25 },
            new Services { Id = 9, Description = "Haircut with Beard Trim", Price = 25, Duration = 55 }
            ];
        }


    }
}