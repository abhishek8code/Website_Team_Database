namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class ProfessionalExperience
    {
        public int ProfessionalExperienceId { get; set; }

        public string Position { get; set; }
        public string Organization { get; set; }
        public string Duration { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }

}
