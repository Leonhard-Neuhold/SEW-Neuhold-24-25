using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Configurations;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<BookDetail> BookDetails { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasDiscriminator<string>("TYPE")
            .HasValue<NonFiction>("NON_FICTION")
            .HasValue<Novel>("NOVEL")
            .HasValue<Textbook>("TEXTBOOK")
            .HasValue<Biography>("BIOGRAPHY")
            .HasValue<ScienceFiction>("SCIENCE_FICTION")
            .HasValue<Fantasy>("FANTASY")
            .HasValue<Mystery>("MYSTERY");

        modelBuilder.Entity<Author>()
            .ToTable("AUTHORS");
        
        modelBuilder.Entity<Customer>()
            .ToTable("CUSTOMERS");
        
        modelBuilder.Entity<Librarian>()
            .ToTable("LIBRARIANS");
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.BookDetail)
            .WithOne()
            .HasForeignKey<Book>(b => b.BookDetailId);
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany()
            .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<BookLoan>()
            .HasKey(bl => new { bl.BookId, bl.CustomerId });
        
        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Book)
            .WithMany()
            .HasForeignKey(bl => bl.BookId);
        
        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Customer)
            .WithMany()
            .HasForeignKey(bl => bl.CustomerId);
        
        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Librarian)
            .WithMany()
            .HasForeignKey(bl => bl.LibrarianId);

    }
}