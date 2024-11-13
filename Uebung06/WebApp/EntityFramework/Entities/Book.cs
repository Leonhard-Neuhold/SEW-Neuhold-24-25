using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

[Table("BOOKS")]
public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BOOK_ID")]
    public int BookId { get; set; }
    
    [Required, Column("TITLE")] 
    public string Title { get; set; }

    [Required, Column("PUBLISHED_DATE")]
    public DateTime PublishedDate { get; set; }

    [Required, Column("ISBN")]
    public string ISBN { get; set; }

    
    public BookDetail BookDetail { get; set; }

    [Required, Column("BOOK_DETAIL_ID")]
    public int BookDetailId { get; set; }


    public Author Author { get; set; }

    [Required, Column("AUTHOR_ID")]
    public int AuthorId { get; set; }
}