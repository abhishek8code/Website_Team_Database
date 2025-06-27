using System;
using System.Collections.Generic;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class DepartmentVision
{
    public int Id { get; set; }

    public int? DeptId { get; set; }

    public string? VisionText { get; set; }
}
