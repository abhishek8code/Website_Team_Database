namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class AdditionalMember :BaseEntity
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }
        public CampusCommittee Committee { get; set; }

        public string CommitteeTitle { get; set; }

        public ICollection<AdditionalMemberDetail> MemberDetails { get; set; }
    }

}
