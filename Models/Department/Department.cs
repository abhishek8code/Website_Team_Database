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

    public bool ShowIntake { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedDateInt { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedDateInt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

}
public partial class Department
{
    public virtual ICollection<DepartmentIntake> DepartmentIntakes { get; set; } = new List<DepartmentIntake>();
}