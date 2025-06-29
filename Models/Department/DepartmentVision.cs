using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;
[Table("Department_Vision")]
public partial class DepartmentVision
{
    [Key]
    public int Id { get; set; }
    [Column("Dept_Id")]
    public int? DeptId { get; set; }

    public string? VisionText { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedDateInt { get; set; }

    public long? UpdatedDateInt { get; set; }
}
