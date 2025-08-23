using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GECPATAN_FACULTY_PORTAL.Models;

[Table("Department")]
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

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public long? CreatedDateInt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedDateInt { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Dept")]
    public virtual ICollection<DepartmentIntake> DepartmentIntakes { get; set; } = new List<DepartmentIntake>();

    [InverseProperty("Dept")]
    public virtual ICollection<DepartmentLab> DepartmentLabs { get; set; } = new List<DepartmentLab>();

    [InverseProperty("Dept")]
    public virtual ICollection<DepartmentMission> DepartmentMissions { get; set; } = new List<DepartmentMission>();

    [InverseProperty("Dept")]
    public virtual ICollection<DepartmentPeo> DepartmentPeos { get; set; } = new List<DepartmentPeo>();

    [InverseProperty("Dept")]
    public virtual ICollection<DepartmentPso> DepartmentPsos { get; set; } = new List<DepartmentPso>();

    [InverseProperty("Dept")]
    public virtual ICollection<DepartmentVision> DepartmentVisions { get; set; } = new List<DepartmentVision>();
}
