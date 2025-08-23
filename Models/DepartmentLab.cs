using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GECPATAN_FACULTY_PORTAL.Models;

[Table("Department_Labs")]
public partial class DepartmentLab
{
    [Key]
    public int LabId { get; set; }

    [Column("Dept_Id")]
    public int DeptId { get; set; }

    [Column("Lab_Name")]
    public string? LabName { get; set; }

    [Column("Lab_Image")]
    public string? LabImage { get; set; }

    [Column("Lab_Details")]
    public string? LabDetails { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedDateInt { get; set; }

    public long? UpdatedDateInt { get; set; }

    [ForeignKey("DeptId")]
    [InverseProperty("DepartmentLabs")]
    public virtual Department Dept { get; set; } = null!;
}
