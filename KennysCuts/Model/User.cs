﻿using Microsoft.AspNetCore.Identity;

namespace KennysCuts.Model
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
