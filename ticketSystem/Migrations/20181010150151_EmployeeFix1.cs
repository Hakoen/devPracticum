using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketSystem.Migrations
{
    public partial class EmployeeFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyID",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyID",
                table: "Employee",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyID",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyID",
                table: "Employee",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
