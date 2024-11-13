using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

[Table("PERSONS")]
public class Person
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("PERSON_ID")]
    public int Person_Id { get; set; }

    [Required, Column("FIRST_NAME")]
    public string FirstName { get; set; }

    [Required, Column("LAST_NAME")]
    public string LastName { get; set; }

    [Required, Column("DATE_OF_BIRTH")]
    public DateTime DateOfBirth { get; set; }
}