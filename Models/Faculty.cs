using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; }
        public string? ImagePath { get; set; }
        public DateTime DateOfJoining { get; set; }

        public string? Qualification { get; set; }
        public string? AreaOfInterest { get; set; }
        public bool IsTeaching { get; set; }

        public string? Website { get; set; }
        public int DeptId { get; set; }

        public int SeniorityOrder { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation
        [ValidateNever]
        public PersonalDetail PersonalDetail { get; set; }
        [ValidateNever]
        public ICollection<EducationalQualification> EducationalQualifications { get; set; }

        [ValidateNever]
        public ICollection<ProfessionalExperience> ProfessionalExperiences { get; set; }

        [ValidateNever] 
        public ICollection<TrainingAndWorkshop> TrainingAndWorkshops { get; set; }

        [ValidateNever]
        public ICollection<Publication> Publications { get; set; }
    }

}
