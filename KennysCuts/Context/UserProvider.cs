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

        public User? GetUserByUsername(string? username)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

        public async Task<User?> GetUserIdAsync(string? id)
        {
            return await _context.Users.FindAsync(id);
        }

    }
}
