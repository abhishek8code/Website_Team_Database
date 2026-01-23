namespace GECPATAN_FACULTY_PORTAL.Models
{ 
    public class CommitteeMission : BaseEntity
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }

        public string MissionText { get; set; }
    }

}
