using System;
using System.Collections.Generic;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class DepartmentMission
{
    public int Id { get; set; }

    public int DeptId { get; set; }

    public string? MissionText { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
