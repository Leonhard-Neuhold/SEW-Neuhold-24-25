﻿// <auto-generated />
using System;
using EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFramework.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityFramework.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BOOK_ID");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("AUTHOR_ID");

                    b.Property<int>("BookDetailId")
                        .HasColumnType("int")
                        .HasColumnName("BOOK_DETAIL_ID");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ISBN");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("PUBLISHED_DATE");

                    b.Property<string>("TYPE")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TITLE");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookDetailId")
                        .IsUnique();

                    b.ToTable("BOOKS");

                    b.HasDiscriminator<string>("TYPE").HasValue("Book");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EntityFramework.Entities.BookDetail", b =>
                {
                    b.Property<int>("BookDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BOOK_DETAIL_ID");

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("int")
                        .HasColumnName("AVAILABLE_COPIES");

                    b.Property<int>("BorrowedCopies")
                        .HasColumnType("int")
                        .HasColumnName("BORROWED_COPIES");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int")
                        .HasColumnName("TOTAL_COPIES");

                    b.HasKey("BookDetailId");

                    b.ToTable("BOOK_DETAILS");
                });

            modelBuilder.Entity("EntityFramework.Entities.BookLoan", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BOOK_ID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DUE_DATE");

                    b.Property<int>("LibrarianId")
                        .HasColumnType("int")
                        .HasColumnName("LIBRARIAN_ID");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LOAN_DATE");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("RETURN_DATE");

                    b.Property<int?>("ReturnLibrarianId")
                        .HasColumnType("int")
                        .HasColumnName("RETURN_LIBRARIAN_ID");

                    b.HasKey("BookId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LibrarianId");

                    b.HasIndex("ReturnLibrarianId");

                    b.ToTable("BOOK_LOANS_JT");
                });

            modelBuilder.Entity("EntityFramework.Entities.Person", b =>
                {
                    b.Property<int>("Person_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATE_OF_BIRTH");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("LAST_NAME");

                    b.HasKey("Person_Id");

                    b.ToTable("PERSONS");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("EntityFramework.Entities.Biography", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("BIOGRAPHY");
                });

            modelBuilder.Entity("EntityFramework.Entities.Fantasy", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("FANTASY");
                });

            modelBuilder.Entity("EntityFramework.Entities.Mystery", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("MYSTERY");
                });

            modelBuilder.Entity("EntityFramework.Entities.NonFiction", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("NON_FICTION");
                });

            modelBuilder.Entity("EntityFramework.Entities.Novel", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("NOVEL");
                });

            modelBuilder.Entity("EntityFramework.Entities.ScienceFiction", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("SCIENCE_FICTION");
                });

            modelBuilder.Entity("EntityFramework.Entities.Textbook", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Book");

                    b.ToTable("BOOKS");

                    b.HasDiscriminator().HasValue("TEXTBOOK");
                });

            modelBuilder.Entity("EntityFramework.Entities.Author", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Person");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("BIOGRAPHY");

                    b.ToTable("AUTHORS", (string)null);
                });

            modelBuilder.Entity("EntityFramework.Entities.Customer", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Person");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("MEMBERSHIP_ID");

                    b.ToTable("CUSTOMERS", (string)null);
                });

            modelBuilder.Entity("EntityFramework.Entities.Librarian", b =>
                {
                    b.HasBaseType("EntityFramework.Entities.Person");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("EMPLOYEE_ID");

                    b.ToTable("LIBRARIANS", (string)null);
                });

            modelBuilder.Entity("EntityFramework.Entities.Book", b =>
                {
                    b.HasOne("EntityFramework.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Entities.BookDetail", "BookDetail")
                        .WithOne()
                        .HasForeignKey("EntityFramework.Entities.Book", "BookDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookDetail");
                });

            modelBuilder.Entity("EntityFramework.Entities.BookLoan", b =>
                {
                    b.HasOne("EntityFramework.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Entities.Librarian", "Librarian")
                        .WithMany()
                        .HasForeignKey("LibrarianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework.Entities.Librarian", "ReturnLibrarian")
                        .WithMany()
                        .HasForeignKey("ReturnLibrarianId");

                    b.Navigation("Book");

                    b.Navigation("Customer");

                    b.Navigation("Librarian");

                    b.Navigation("ReturnLibrarian");
                });

            modelBuilder.Entity("EntityFramework.Entities.Author", b =>
                {
                    b.HasOne("EntityFramework.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("EntityFramework.Entities.Author", "Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework.Entities.Customer", b =>
                {
                    b.HasOne("EntityFramework.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("EntityFramework.Entities.Customer", "Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework.Entities.Librarian", b =>
                {
                    b.HasOne("EntityFramework.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("EntityFramework.Entities.Librarian", "Person_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
