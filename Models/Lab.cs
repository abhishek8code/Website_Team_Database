using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Tar;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class Lab : BaseEntity
    {
        public int LabId { get; set; }

        public int DeptId { get; set; }
        public string? LabName { get; set; }

        public string? LabImage { get; set; }

        public string? LabDetails { get; set; }
    }
}
