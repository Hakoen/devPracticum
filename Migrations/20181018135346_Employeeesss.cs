using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketSystem.Migrations
{
    public partial class Employeeesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employee",
                nullable: true);
        }
    }
}
