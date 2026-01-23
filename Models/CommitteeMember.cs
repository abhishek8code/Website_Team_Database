namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class CommitteeMember : BaseEntity
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }
        public CampusCommittee Committee { get; set; }

        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }

}
