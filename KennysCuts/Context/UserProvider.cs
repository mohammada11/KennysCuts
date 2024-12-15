using KennysCuts.Model;
using Microsoft.AspNetCore.Identity;

namespace KennysCuts.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Gets a user by their username from the database.
        public User? GetUserByUsername(string? username)
        {
            // Finds the first user in the database whose UserName matches the provided username.
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

        // Returns a user by their ID from the database.
        public async Task<User?> GetUserIdAsync(string? id)
        {
            // A method to locate a user by their ID.
            return await _context.Users.FindAsync(id);
        }


    }
}
