namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class FacultyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string EmailID { get; set; }  // Maps to "Email ID" in the table
        public string Department { get; set; }
    }

}
