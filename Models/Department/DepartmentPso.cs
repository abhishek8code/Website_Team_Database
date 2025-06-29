using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GECPATAN_FACULTY_PORTAL.Models.Department;
[Table("Department_PSOs")]
public partial class DepartmentPso
{
    public int Id { get; set; }
    [Column("Dept_Id")]
    public int DeptId { get; set; }

    public string? Psotext { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public long? CreatedDateInt { get; set; }

    public long? UpdatedDateInt { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
