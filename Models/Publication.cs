namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }

        public int SrNo { get; set; }
        public string Title { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }

}
