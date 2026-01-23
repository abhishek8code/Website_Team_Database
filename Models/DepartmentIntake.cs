using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class DepartmentIntake : BaseEntity
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public int? IntakeCount { get; set; }
        public DateTime? IntakeYear { get; set; }
        public Departments? Department { get; set; }
    }
}
