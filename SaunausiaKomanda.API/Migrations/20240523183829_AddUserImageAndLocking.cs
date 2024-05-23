using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaunausiaKomanda.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserImageAndLocking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Username",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "User",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Step",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Review",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Recipe",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Ingredient",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Image",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Favorite",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Category",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_User_ImageId",
                table: "User",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Image_ImageId",
                table: "User",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Image_ImageId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ImageId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }
    }
}
