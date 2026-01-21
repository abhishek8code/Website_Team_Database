using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class ProfessionalExperience
    {
        public int ProfessionalExperienceId { get; set; }

        public string Position { get; set; }
        public string Organization { get; set; }
        public string Duration { get; set; }

        public int FacultyId { get; set; }
        [ValidateNever]
        public Faculty Faculty { get; set; }

    }

}
