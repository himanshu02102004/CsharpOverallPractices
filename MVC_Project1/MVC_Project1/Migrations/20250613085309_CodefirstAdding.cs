using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project1.Migrations
{
    /// <inheritdoc />
    public partial class CodefirstAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "standard",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "standard",
                table: "students");
        }
    }
}
