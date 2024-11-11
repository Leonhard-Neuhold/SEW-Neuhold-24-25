using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

[Table("BOOKS")]
public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ITEM_ID")]
    public int Id { get; set; }
    
    [Required, Column("TITLE")] 
    public string Title { get; set; }
    
    [Required, Column("AUTHOR")] 
    public string Author { get; set; }

    [Required, Column("PUBLISHED_DATE")]
    public DateTime PublishedDate { get; set; }

    [Required, Column("ISBN")]
    public string ISBN { get; set; }

    [Required, Column("AVAILABLE_PRICE")]
    public int AvailableCopies { get; set; }
}