namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class TrainingAndWorkshop
    {
        public int TrainingAndWorkshopId { get; set; }

        public string Title { get; set; }
        public string OrganizedBy { get; set; }
        public string Date { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }

}
