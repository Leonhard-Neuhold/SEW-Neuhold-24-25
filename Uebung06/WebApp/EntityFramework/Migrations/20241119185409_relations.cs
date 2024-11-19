using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BOOK_DETAILS",
                columns: table => new
                {
                    BOOK_DETAIL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TOTAL_COPIES = table.Column<int>(type: "int", nullable: false),
                    BORROWED_COPIES = table.Column<int>(type: "int", nullable: false),
                    AVAILABLE_COPIES = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK_DETAILS", x => x.BOOK_DETAIL_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PERSONS",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LAST_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONS", x => x.PERSON_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AUTHORS",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    BIOGRAPHY = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORS", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "FK_AUTHORS_PERSONS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSONS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    MEMBERSHIP_ID = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMERS_PERSONS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSONS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LIBRARIANS",
                columns: table => new
                {
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_ID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIBRARIANS", x => x.PERSON_ID);
                    table.ForeignKey(
                        name: "FK_LIBRARIANS_PERSONS_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSONS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BOOKS",
                columns: table => new
                {
                    BOOK_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PUBLISHED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ISBN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BOOK_DETAIL_ID = table.Column<int>(type: "int", nullable: false),
                    AUTHOR_ID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS", x => x.BOOK_ID);
                    table.ForeignKey(
                        name: "FK_BOOKS_AUTHORS_AUTHOR_ID",
                        column: x => x.AUTHOR_ID,
                        principalTable: "AUTHORS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOKS_BOOK_DETAILS_BOOK_DETAIL_ID",
                        column: x => x.BOOK_DETAIL_ID,
                        principalTable: "BOOK_DETAILS",
                        principalColumn: "BOOK_DETAIL_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BOOK_LOANS_JT",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    BOOK_ID = table.Column<int>(type: "int", nullable: false),
                    LOAN_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LIBRARIAN_ID = table.Column<int>(type: "int", nullable: false),
                    RETURN_LIBRARIAN_ID = table.Column<int>(type: "int", nullable: true),
                    RETURN_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK_LOANS_JT", x => new { x.BOOK_ID, x.CUSTOMER_ID });
                    table.ForeignKey(
                        name: "FK_BOOK_LOANS_JT_BOOKS_BOOK_ID",
                        column: x => x.BOOK_ID,
                        principalTable: "BOOKS",
                        principalColumn: "BOOK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_LOANS_JT_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_LOANS_JT_LIBRARIANS_LIBRARIAN_ID",
                        column: x => x.LIBRARIAN_ID,
                        principalTable: "LIBRARIANS",
                        principalColumn: "PERSON_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_LOANS_JT_LIBRARIANS_RETURN_LIBRARIAN_ID",
                        column: x => x.RETURN_LIBRARIAN_ID,
                        principalTable: "LIBRARIANS",
                        principalColumn: "PERSON_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_LOANS_JT_CUSTOMER_ID",
                table: "BOOK_LOANS_JT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_LOANS_JT_LIBRARIAN_ID",
                table: "BOOK_LOANS_JT",
                column: "LIBRARIAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_LOANS_JT_RETURN_LIBRARIAN_ID",
                table: "BOOK_LOANS_JT",
                column: "RETURN_LIBRARIAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_AUTHOR_ID",
                table: "BOOKS",
                column: "AUTHOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_BOOK_DETAIL_ID",
                table: "BOOKS",
                column: "BOOK_DETAIL_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOK_LOANS_JT");

            migrationBuilder.DropTable(
                name: "BOOKS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "LIBRARIANS");

            migrationBuilder.DropTable(
                name: "AUTHORS");

            migrationBuilder.DropTable(
                name: "BOOK_DETAILS");

            migrationBuilder.DropTable(
                name: "PERSONS");
        }
    }
}
