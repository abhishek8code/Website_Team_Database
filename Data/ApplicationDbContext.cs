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
        public DbSet<FacultyMember> FacultyMember { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentIntake> DepartmentIntakes { get; set; }
        public DbSet<DepartmentLab> DepartmentLabs { get; set; }
        public DbSet<DepartmentMission> DepartmentMissions { get; set; }
        public DbSet<DepartmentPeo> DepartmentPeos { get; set; }
        public DbSet<DepartmentPso> DepartmentPsos { get; set; }
        public DbSet<DepartmentVision> DepartmentVisions { get; set; }

    }
}
