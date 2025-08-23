//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace GECPATAN_FACULTY_PORTAL.Models;

//public partial class ApplicationDbContext: DbContext
//{
//    public FacultyPortalContext()
//    {
//    }

//    public FacultyPortalContext(DbContextOptions<FacultyPortalContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Department> Departments { get; set; }

//    public virtual DbSet<DepartmentIntake> DepartmentIntakes { get; set; }

//    public virtual DbSet<DepartmentLab> DepartmentLabs { get; set; }

//    public virtual DbSet<DepartmentMission> DepartmentMissions { get; set; }

//    public virtual DbSet<DepartmentPeo> DepartmentPeos { get; set; }

//    public virtual DbSet<DepartmentPso> DepartmentPsos { get; set; }

//    public virtual DbSet<DepartmentVision> DepartmentVisions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GECPATAN_FACULTY_PORTAL;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Department>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07D1D3E59B");
//        });

//        modelBuilder.Entity<DepartmentIntake>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC075958F2BD");

//            entity.HasOne(d => d.Dept).WithMany(p => p.DepartmentIntakes)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_DepartmentIntake_Department");
//        });

//        modelBuilder.Entity<DepartmentLab>(entity =>
//        {
//            entity.HasKey(e => e.LabId).HasName("PK__Departme__EDBD68DA22D0A771");

//            entity.HasOne(d => d.Dept).WithMany(p => p.DepartmentLabs)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_DepartmentLabs_Department");
//        });

//        modelBuilder.Entity<DepartmentMission>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC073F024623");

//            entity.HasOne(d => d.Dept).WithMany(p => p.DepartmentMissions)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_DepartmentMission_Department");
//        });

//        modelBuilder.Entity<DepartmentPeo>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07F447CB62");

//            entity.HasOne(d => d.Dept).WithMany(p => p.DepartmentPeos)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_DepartmentPeo_Department");
//        });

//        modelBuilder.Entity<DepartmentPso>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07D04976DA");

//            entity.HasOne(d => d.Dept).WithMany(p => p.DepartmentPsos)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_DepartmentPso_Department");
//        });

//        modelBuilder.Entity<DepartmentVision>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC073355066F");

//            entity.HasOne(d => d.Dept).WithMany(p => p.DepartmentVisions).HasConstraintName("FK_DepartmentVision_Department");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
