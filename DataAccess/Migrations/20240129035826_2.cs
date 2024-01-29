using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_EmployeeWorkingDayOrHour_EmployeeId",
                table: "EmployeeWorkingDayOrHour",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkingDayOrHour");
        }
    }
}
