using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Entities;

[Table("BOOK_LOANS_JT")]
public class BookLoan
{
    public Customer Customer { get; set; }

    [Required, Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }


    public Book Book { get; set; }

    [Required, Column("BOOK_ID")]
    public int BookId { get; set; }
    

    [Required, Column("LOAN_DATE")]
    public DateTime LoanDate { get; set; }

    [Required, Column("DUE_DATE")]
    public DateTime DueDate { get; set; }

    
    public Librarian Librarian { get; set; }

    [Required, Column("LIBRARIAN_ID")]
    public int LibrarianId { get; set; }


    public Librarian ReturnLibrarian { get; set; }

    [Column("RETURN_LIBRARIAN_ID")]
    public Librarian ReturnLibrarianId { get; set; }

    
    [Column("RETURN_DATE")]
    public DateTime ReturnDate { get; set; }
}