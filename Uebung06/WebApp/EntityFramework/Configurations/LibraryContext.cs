using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Configurations;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

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
    }
}