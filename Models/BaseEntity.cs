namespace GECPATAN_FACULTY_PORTAL.Models
{
    public abstract class BaseEntity
    {
        public int BaseId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; }
        public long CreatedDateInt { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedDateInt { get; set; }
    }
}
