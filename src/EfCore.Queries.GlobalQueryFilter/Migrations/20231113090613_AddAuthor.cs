using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfCore.Queries.GlobalQueryFilter.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DeletedTime", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"), null, false, "Andrew Troelsen" },
                    { new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"), new DateTimeOffset(new DateTime(2023, 11, 13, 14, 6, 13, 448, DateTimeKind.Unspecified).AddTicks(612), new TimeSpan(0, 5, 0, 0, 0)), true, "Mark. J. Price" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
