namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class CommitteeVision : BaseEntity
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }

        public string VisionText { get; set; }
    }
}

