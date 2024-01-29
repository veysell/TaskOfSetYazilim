using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FixedSalaryAmount = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    OvertimeAmount = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    DailyAmount = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    InternationalId = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Tip 1" },
                    { 2, true, "Tip 2" },
                    { 3, true, "Tip 3" }
                });

            migrationBuilder.InsertData(
                table: "Revenues",
                columns: new[] { "Id", "DailyAmount", "FixedSalaryAmount", "IsActive", "Name", "OvertimeAmount", "PeriodEnd", "PeriodStart" },
                values: new object[] { 1, 150.75m, 5000.00m, true, "Ocak-Mayıs Dönemi Ödeme Miktarları", 200.50m, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeTypeId", "InternationalId", "IsActive", "Name", "SurName" },
                values: new object[,]
                {
                    { 1, 1, "12345678911", true, "Ahmet", "Dur" },
                    { 2, 2, "98765432100", true, "Mehmet", "Yılmaz" },
                    { 3, 1, "45678912300", true, "Ayşe", "Yıldız" },
                    { 4, 2, "65432198700", true, "Fatma", "Kaya" },
                    { 5, 1, "78912345600", true, "Mustafa", "Şahin" },
                    { 6, 2, "01234567890", true, "Zeynep", "Aydın" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");
        }
    }
}
