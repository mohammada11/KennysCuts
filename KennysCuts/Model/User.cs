using Microsoft.AspNetCore.Identity;

namespace KennysCuts.Model
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
