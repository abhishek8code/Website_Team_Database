namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class CommitteeObjective : BaseEntity
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }

        public string ObjectiveText { get; set; }
    }

}
