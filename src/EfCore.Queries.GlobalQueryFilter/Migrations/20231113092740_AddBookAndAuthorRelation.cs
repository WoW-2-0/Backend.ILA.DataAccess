using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore.Queries.GlobalQueryFilter.Migrations
{
    /// <inheritdoc />
    public partial class AddBookAndAuthorRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    Pages = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"),
                column: "DeletedTime",
                value: new DateTimeOffset(new DateTime(2023, 11, 13, 14, 27, 40, 808, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "DeletedTime", "Genre", "IsDeleted", "Pages", "Title" },
                values: new object[,]
                {
                    { new Guid("4abd35a4-1d02-4e3f-9cca-50446c824540"), null, "Programming", false, 1376, "Pro C# 7: With .NET and .NET Core" },
                    { new Guid("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686"), null, "Programming", false, 900, "Complete C# 7 Design Patterns" },
                    { new Guid("ea55317a-2836-46f6-ad53-d10da0647ed9"), new DateTimeOffset(new DateTime(2023, 11, 13, 14, 27, 40, 809, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 5, 0, 0, 0)), "Programming", true, 900, "Pro C# 12 with .NET 8" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"), new Guid("4abd35a4-1d02-4e3f-9cca-50446c824540") },
                    { new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"), new Guid("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686") },
                    { new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"), new Guid("ea55317a-2836-46f6-ad53-d10da0647ed9") },
                    { new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"), new Guid("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"),
                column: "DeletedTime",
                value: new DateTimeOffset(new DateTime(2023, 11, 13, 14, 6, 13, 448, DateTimeKind.Unspecified).AddTicks(612), new TimeSpan(0, 5, 0, 0, 0)));
        }
    }
}
