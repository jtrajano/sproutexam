using Microsoft.EntityFrameworkCore.Migrations;

namespace Sprout.Exam.DataAccess
{
    public partial class EmployeeTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Employee",
                newName: "EmployeeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeTypeId",
                table: "Employee",
                newName: "TypeId");
        }
    }
}
