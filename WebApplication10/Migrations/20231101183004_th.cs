using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication10.Migrations
{
    /// <inheritdoc />
    public partial class th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
