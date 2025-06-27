using System;
using System.Collections.Generic;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class DepartmentPeos
{
    public int Id { get; set; }

    public int DeptId { get; set; }

    public string? Peotext { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
