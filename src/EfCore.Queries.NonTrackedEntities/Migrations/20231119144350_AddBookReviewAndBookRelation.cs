using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore.Queries.NonTrackedEntities.Migrations
{
    /// <inheritdoc />
    public partial class AddBookReviewAndBookRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Review = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookReviews",
                columns: new[] { "Id", "BookId", "Review" },
                values: new object[,]
                {
                    { new Guid("1c832fc1-1146-4aa8-819c-e6e0788a4e50"), new Guid("aea165f8-69e5-4605-b45b-1e66227445ba"), "Great book" },
                    { new Guid("c7e81257-582e-4b4f-96d3-96dc8506b9da"), new Guid("aea165f8-69e5-4605-b45b-1e66227445ba"), "Awesome book" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReviews");
        }
    }
}
