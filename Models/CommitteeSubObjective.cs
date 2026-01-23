namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class CommitteeSubObjective : BaseEntity
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }

        public string SubObjectiveText { get; set; }
    }
}
