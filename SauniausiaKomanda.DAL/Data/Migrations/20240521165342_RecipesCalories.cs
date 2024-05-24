using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SauniausiaKomanda.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RecipesCalories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Recipe",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Recipe");
        }
    }
}
