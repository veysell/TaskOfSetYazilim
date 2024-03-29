﻿using System;
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
                name: "SalaryInfos",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.CreateTable(
                name: "EmployeeWorkingDayOrHour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkingDayOrHour = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkingDayOrHour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkingDayOrHour_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
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
                values: new object[] { 1, 1500.75m, 25000.00m, true, "Ocak-Mayıs Dönemi Ödeme Miktarları", 500.50m, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeTypeId", "InternationalId", "IsActive", "Name", "SurName" },
                values: new object[,]
                {
                    { 1, 1, "12345678911", true, "Ahmet", "Dur" },
                    { 2, 1, "12444678911", true, "Ahmet", "Akça" },
                    { 3, 2, "98765432100", true, "Mehmet", "Yılmaz" },
                    { 4, 2, "98765552100", true, "Mehmet", "Tuna" },
                    { 5, 3, "45678912300", true, "Ayşe", "Yıldız" },
                    { 6, 3, "41118912300", true, "Ayşe", "Yalnız" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeWorkingDayOrHour",
                columns: new[] { "Id", "EmployeeId", "IsActive", "WorkingDayOrHour" },
                values: new object[,]
                {
                    { 1, 3, true, 2m },
                    { 2, 4, true, 2m },
                    { 3, 5, true, 2m },
                    { 4, 6, true, 2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkingDayOrHour_EmployeeId",
                table: "EmployeeWorkingDayOrHour",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkingDayOrHour");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "SalaryInfos");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");
        }
    }
}
