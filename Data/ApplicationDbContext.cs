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

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<EducationalQualification> EducationalQualifications { get; set; }
        public DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }
        public DbSet<TrainingAndWorkshop> TrainingAndWorkshops { get; set; }
        public DbSet<Publication> Publications { get; set; }


        public DbSet<CampusCommittee> CampusCommittees { get; set; }

        public DbSet<CommitteeVision> CommitteeVisions { get; set; }
        public DbSet<CommitteeMission> CommitteeMissions { get; set; }
        public DbSet<CommitteeObjective> CommitteeObjectives { get; set; }
        public DbSet<CommitteeSubObjective> CommitteeSubObjectives { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<AdditionalMember> AdditionalMembers { get; set; }
        public DbSet<AdditionalMemberDetail> AdditionalMemberDetails { get; set; }


        // 🔥 GLOBAL SOFT DELETE FILTER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Faculty>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<ProfessionalExperience>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<TrainingAndWorkshop>()
                .HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.Entity<Publication>()
                .HasQueryFilter(x => !x.IsDeleted);
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
