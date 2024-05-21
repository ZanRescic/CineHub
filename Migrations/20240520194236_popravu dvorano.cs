using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineHub.Migrations
{
    /// <inheritdoc />
    public partial class popravudvorano : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Dvorana",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ime",
                table: "Dvorana");

        }
    }
}
