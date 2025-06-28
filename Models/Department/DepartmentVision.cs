using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

[Table("Department_Vision")] 
public partial class DepartmentVision
{
    public int Id { get; set; }
    [Column("Dept_ID")]
    public int? DeptId { get; set; }

    public string? VisionText { get; set; }
}
