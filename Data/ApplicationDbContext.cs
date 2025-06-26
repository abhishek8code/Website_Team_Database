using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GECPATAN_FACULTY_PORTAL.Models;
namespace GECPATAN_FACULTY_PORTAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GECPATAN_FACULTY_PORTAL.Models.FacultyMember> FacultyMember { get; set; } = default!;
    }
}
