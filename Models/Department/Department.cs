using System;
using System.Collections.Generic;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Slogan { get; set; }

    public string? Tagline { get; set; }

    public string? TitleImage { get; set; }

    public string? About { get; set; }

    public bool? ShowIntake { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedDateInt { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedDateInt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<DepartmentIntake> DepartmentIntake { get; set; } = new List<DepartmentIntake>();

//    public virtual ICollection<DepartmentLabs> DepartmentLabs { get; set; } = new List<DepartmentLabs>();

    public virtual ICollection<DepartmentMission> DepartmentMission { get; set; } = new List<DepartmentMission>();

    public virtual ICollection<DepartmentPeos> DepartmentPeos { get; set; } = new List<DepartmentPeos>();

    public virtual ICollection<DepartmentPsos> DepartmentPsos { get; set; } = new List<DepartmentPsos>();
}
