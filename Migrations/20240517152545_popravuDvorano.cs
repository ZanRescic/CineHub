using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineHub.Migrations
{
    /// <inheritdoc />
    public partial class popravuDvorano : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Dvorana");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dvorana",
                table: "Dvorana",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dvorana",
                table: "Dvorana");

            migrationBuilder.RenameTable(
                name: "Dvorana",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "id");
        }
    }
}
