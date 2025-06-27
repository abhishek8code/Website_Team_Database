using System;
using System.Collections.Generic;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class DepartmentIntake
{
    public int Id { get; set; }

    public int DeptId { get; set; }

    public int? IntakeCount { get; set; }

    public DateTime? IntakeYear { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
