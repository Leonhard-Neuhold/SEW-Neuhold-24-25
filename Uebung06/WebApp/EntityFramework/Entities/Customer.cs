using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

public class Customer : Person
{
    [Required, Column("MEMBERSHIP_ID")]
    public DateTime MembershipDate { get; set; }
}