using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GECPATAN_FACULTY_PORTAL.Models;

namespace GECPATAN_FACULTY_PORTAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Faculty Module
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<EducationalQualification> EducationalQualifications { get; set; }
        public DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }
        public DbSet<TrainingAndWorkshop> TrainingAndWorkshops { get; set; }
        public DbSet<Publication> Publications { get; set; }

        //Campus Committee Module
        public DbSet<CampusCommittee> CampusCommittees { get; set; }

        public DbSet<CommitteeVision> CommitteeVisions { get; set; }
        public DbSet<CommitteeMission> CommitteeMissions { get; set; }
        public DbSet<CommitteeObjective> CommitteeObjectives { get; set; }
        public DbSet<CommitteeSubObjective> CommitteeSubObjectives { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<AdditionalMember> AdditionalMembers { get; set; }
        public DbSet<AdditionalMemberDetail> AdditionalMemberDetails { get; set; }
        //Department Module
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<DepartmentVision> DepartmentVisions { get; set; }
        public DbSet<DepartmentMission> DepartmentMissions { get; set; }
        public DbSet<DepartmentPEO> DepartmentPEOs { get; set; }
        public DbSet<DepartmentPSO> DepartmentPSOs { get; set; }
        public DbSet<DepartmentIntake> DepartmentIntakes { get; set; }

        //GLOBAL SOFT DELETE FILTER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Faculty Module
            modelBuilder.Entity<Faculty>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PersonalDetail>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<EducationalQualification>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ProfessionalExperience>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<TrainingAndWorkshop>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Publication>().HasQueryFilter(x => !x.IsDeleted);

            // Campus Committee Module
            modelBuilder.Entity<CampusCommittee>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CommitteeVision>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CommitteeMission>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CommitteeObjective>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CommitteeSubObjective>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<CommitteeMember>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<AdditionalMember>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<AdditionalMemberDetail>().HasQueryFilter(x => !x.IsDeleted);

            // Department Module
            modelBuilder.Entity<Departments>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Lab>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<DepartmentVision>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<DepartmentMission>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<DepartmentPEO>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<DepartmentPSO>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<DepartmentIntake>().HasQueryFilter(x => !x.IsDeleted);
        }


        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfo()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedDateInt =
                        DateTimeOffset.Now.ToUnixTimeSeconds();
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.Now;
                    entry.Entity.UpdatedDateInt =
                        DateTimeOffset.Now.ToUnixTimeSeconds();
                }
            }
        }
    }
}
