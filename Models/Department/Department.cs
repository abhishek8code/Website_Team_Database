using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;

public partial class Department
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? Slogan { get; set; }

    public string? Tagline { get; set; }

    public string? TitleImage { get; set; }

    public string? About { get; set; }

    public bool ShowIntake { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedDateInt { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedDateInt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<DepartmentIntake> DepartmentIntakes { get; set; } = new List<DepartmentIntake>();

    public virtual ICollection<DepartmentLab> DepartmentLabs { get; set; } = new List<DepartmentLab>();

    public virtual ICollection<DepartmentMission> DepartmentMissions { get; set; } = new List<DepartmentMission>();

    public virtual ICollection<DepartmentPeo> DepartmentPeos { get; set; } = new List<DepartmentPeo>();

    public virtual ICollection<DepartmentPso> DepartmentPsos { get; set; } = new List<DepartmentPso>();
}
