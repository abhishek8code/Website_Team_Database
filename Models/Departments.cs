using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class Departments : BaseEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Slogan { get; set; }

        public string? Tagline { get; set; }

        public string? TitleImage { get; set; }

        public string? About { get; set; }

        public bool ShowIntake { get; set; }

        /* Navigation Properties */
        [ValidateNever] public ICollection<DepartmentVision> Visions { get; set; }
        [ValidateNever] public ICollection<DepartmentMission> Missions { get; set; }
        [ValidateNever] public ICollection<DepartmentPEO> PEOs { get; set; }
        [ValidateNever] public ICollection<DepartmentPSO> PSOs { get; set; }
        [ValidateNever] public ICollection<Lab> Labs { get; set; }
    }
}
    