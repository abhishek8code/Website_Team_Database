using System;
using System.Collections.Generic;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class DepartmentPsos
{
    public int Id { get; set; }

    public int DeptId { get; set; }

    public string? Psotext { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
