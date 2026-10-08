using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Models.Auth_User
{
    public class AppUser : IdentityUser
    {
        public string FName { get; set; } = null!;
        public string? LName { get; set; } 
    }
}
