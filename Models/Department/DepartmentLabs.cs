using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;
[Table("Department_Labs")]
public partial class DepartmentLabs
{
    [Key]
    public int LabId { get; set; }
    [Column("Dept_Id")]
    public int DeptId { get; set; }
    [Column("Lab_Name")]
    public string? LabName { get; set; }
    [Column("Lab_Image")]
    public string? LabImage { get; set; }
    [Column("Lab_Details")]
    public string? LabDetails { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
