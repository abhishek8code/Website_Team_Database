using System;
using System.Collections.Generic;
using GECPATAN_FACULTY_PORTAL.Models.Department;
using Microsoft.EntityFrameworkCore;

namespace GECPATAN_FACULTY_PORTAL.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Department> Departments { get; set; }

    public virtual DbSet<Department> Department { get; set; }

    public virtual DbSet<DepartmentIntake> DepartmentIntake { get; set; }

   // public virtual DbSet<DepartmentLabs> DepartmentLabs { get; set; }

    public virtual DbSet<DepartmentMission> DepartmentMission { get; set; }

    public virtual DbSet<DepartmentPeos> DepartmentPeos { get; set; }

    public virtual DbSet<DepartmentPsos> DepartmentPsos { get; set; }

    public virtual DbSet<DepartmentVision> DepartmentVision { get; set; }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
