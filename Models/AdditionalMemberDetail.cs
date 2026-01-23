namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class AdditionalMemberDetail : BaseEntity
    {
        public int Id { get; set; }

        public int AdditionalMemberId { get; set; }
        public AdditionalMember AdditionalMember { get; set; }

        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}

