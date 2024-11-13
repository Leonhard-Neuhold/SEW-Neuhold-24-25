using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

public class Librarian : Person
{
    [Required, Column("EMPLOYEE_ID")]
    public string EmployeeId { get; set; }
}