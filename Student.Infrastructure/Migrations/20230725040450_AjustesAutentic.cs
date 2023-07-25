using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesAutentic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Students",
                newName: "Email");
        }
    }
}
