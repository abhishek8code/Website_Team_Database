using System;
using System.Collections.Generic;
using GECPATAN_FACULTY_PORTAL.Models;
using GECPATAN_FACULTY_PORTAL.Models.Department;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GECPATAN_FACULTY_PORTAL.Data;

public partial class ApplicationDbContext : IdentityDbContext<Users>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentIntake> DepartmentIntakes { get; set; }

    public virtual DbSet<DepartmentLab> DepartmentLabs { get; set; }

    public virtual DbSet<DepartmentMission> DepartmentMissions { get; set; }

    public virtual DbSet<DepartmentPeo> DepartmentPeos { get; set; }

    public virtual DbSet<DepartmentPso> DepartmentPsos { get; set; }

    public virtual DbSet<DepartmentVision> DepartmentVisions { get; set; }

    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
