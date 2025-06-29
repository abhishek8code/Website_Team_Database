using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;
[Table("Department_Intake")]

public partial class DepartmentIntake
{
    public int Id { get; set; }
    [Column("Dept_Id")]
    public int DeptId { get; set; }
    [Column("Intake_Count")]
    public int? IntakeCount { get; set; }
    [Column("Intake_Year")]
    public DateTime? IntakeYear { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedDateInt { get; set; }

    public long? UpdatedDateInt { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
