using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

public class Author : Person
{
    [Required, Column("BIOGRAPHY")]
    public string Biography { get; set; }
}