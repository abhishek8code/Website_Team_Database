using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;
[Table("Department_PSOs")]
public partial class DepartmentPsos
{
    public int Id { get; set; }
    [Column("Dept_Id")]
    public int DeptId { get; set; }

    public string? Psotext { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
