using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GECPATAN_FACULTY_PORTAL.Models;

[Table("Department_Mission")]
public partial class DepartmentMission
{
    [Key]
    public int Id { get; set; }

    [Column("Dept_Id")]
    public int DeptId { get; set; }

    public string? MissionText { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedDateInt { get; set; }

    public long? UpdatedDateInt { get; set; }

    [ForeignKey("DeptId")]
    [InverseProperty("DepartmentMissions")]
    public virtual Department Dept { get; set; } = null!;
}
