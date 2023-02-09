using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOffice.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class AddedSaltEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Employees");
        }
    }
}
