namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class EducationalQualification
    {
        public int EducationalQualificationId { get; set; }

        public string Degree { get; set; }
        public string University { get; set; }
        public string Year { get; set; }
        public string Specialization { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }

}
