namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class DepartmentVision : BaseEntity
    {
        public int Id { get; set; }

        public int Dept_ID { get; set; }
        public Departments? Department { get; set; }

        public string? VisionText { get; set; }
    }
}
