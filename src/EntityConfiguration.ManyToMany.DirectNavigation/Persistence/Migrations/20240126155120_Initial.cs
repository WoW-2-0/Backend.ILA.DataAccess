using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityConfiguration.ManyToMany.DirectNavigation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4399c1f6-896e-4d54-a88f-1d7206d8997f"), "Martin Fowler" },
                    { new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"), "Andrew Troelsen" },
                    { new Guid("6cef5459-8106-4086-a613-5b19afde6163"), "Steve McConnell" },
                    { new Guid("a67cdffc-f7a4-4d23-a882-49a6df9c817f"), "Robert C. Martin" },
                    { new Guid("b657d94d-0710-415c-8c31-a5e8680b31ed"), "Eric Evans" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "Title" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"), "Programming", "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"), "Programming", "Refactoring: Improving the Design of Existing Code" },
                    { new Guid("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8"), "Programming", "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { new Guid("d4e5f6a7-b8c9-4ad0-e1f2-a3b4c5d6e7f8"), "Programming", "Code Complete: A Practical Handbook of Software Construction" },
                    { new Guid("e6f7a8b9-c0d1-4ae2-f3b4-c5d6e7f8a9b0"), "Programming", "Patterns of Enterprise Application Architecture" },
                    { new Guid("e9582b0d-a6c7-4fdb-b17b-7e9d64e5b784"), "Programming", "Pro C# 7: With .NET and .NET Core" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("4399c1f6-896e-4d54-a88f-1d7206d8997f"), new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7") },
                    { new Guid("4399c1f6-896e-4d54-a88f-1d7206d8997f"), new Guid("e6f7a8b9-c0d1-4ae2-f3b4-c5d6e7f8a9b0") },
                    { new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"), new Guid("e9582b0d-a6c7-4fdb-b17b-7e9d64e5b784") },
                    { new Guid("6cef5459-8106-4086-a613-5b19afde6163"), new Guid("d4e5f6a7-b8c9-4ad0-e1f2-a3b4c5d6e7f8") },
                    { new Guid("a67cdffc-f7a4-4d23-a882-49a6df9c817f"), new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6") },
                    { new Guid("b657d94d-0710-415c-8c31-a5e8680b31ed"), new Guid("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8") },
                    { new Guid("b657d94d-0710-415c-8c31-a5e8680b31ed"), new Guid("e6f7a8b9-c0d1-4ae2-f3b4-c5d6e7f8a9b0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
