using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

[Table("BOOK_DETAILS")]
public class BookDetail
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BOOK_DETAIL_ID")]
    public int BookDetailId { get; set; }

    [Required, Column("TOTAL_COPIES")]
    public int TotalCopies { get; set; }

    [Required, Column("BORROWED_COPIES")]
    public int BorrowedCopies { get; set; }

    [Required, Column("AVAILABLE_COPIES")]
    public int AvailableCopies { get; set; }
}