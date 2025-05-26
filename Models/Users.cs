using Microsoft.AspNetCore.Identity;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class Users : IdentityUser
    {
        public required string Role { get; set; }
        public required string Name { get; set; }

    }
}


     