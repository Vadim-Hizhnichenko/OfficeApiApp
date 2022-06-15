using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataOfBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Java" },
                    { 2, ".Net" },
                    { 3, "Python" },
                    { 4, "QA" },
                    { 5, "HR" },
                    { 6, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DataOfBirthday", "DepartmentId", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 2, new DateTime(1979, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jhon", 1, "Ready" },
                    { 3, new DateTime(1998, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alex", 1, "Leus" },
                    { 4, new DateTime(1996, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nikol", 2, "Zeus" },
                    { 5, new DateTime(1994, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dima", 1, "Mykulenko" },
                    { 6, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Sergey", 1, "Reva" },
                    { 7, new DateTime(1990, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Olena", 2, "Ivanova" },
                    { 9, new DateTime(1996, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bogdan", 1, "Bogdanovich" },
                    { 1, new DateTime(1994, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Alis", 2, "Roud" },
                    { 8, new DateTime(1999, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Anastasiya", 2, "Reznik" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
