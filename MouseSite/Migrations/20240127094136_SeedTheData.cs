using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MouseSite.Migrations
{
    /// <inheritdoc />
    public partial class SeedTheData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categs",
                columns: new[] { "CategoryId", "DisplayOrder", "MyProperty3", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, "SciFi" },
                    { 2, 2, 0, "Action" },
                    { 3, 3, 0, "Fiction" },
                    { 4, 24, 0, "Fantasy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categs",
                keyColumn: "CategoryId",
                keyValue: 4);
        }
    }
}
