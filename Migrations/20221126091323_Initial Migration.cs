using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EMPID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIDDLENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTACT = table.Column<int>(type: "int", nullable: false),
                    DEGREE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SALARY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EMPID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
