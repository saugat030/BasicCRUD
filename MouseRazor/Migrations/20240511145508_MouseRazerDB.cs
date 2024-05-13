using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MouseRazor.Migrations
{
    /// <inheritdoc />
    public partial class MouseRazerDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categs",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    MyProperty3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categs", x => x.CategoryId);
                });

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
            migrationBuilder.DropTable(
                name: "Categs");
        }
    }
}
