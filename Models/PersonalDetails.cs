namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class PersonalDetail:BaseEntity
    {
        public int PersonalDetailId { get; set; }

        public string Department { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
