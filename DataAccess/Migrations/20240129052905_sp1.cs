using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class sp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE PROCEDURE sp_CalculateAllSalary
                                    AS
                                    BEGIN
                                        DECLARE @CurrentDate DATE = GETDATE();

                                        SELECT
                                            e.Name,
                                            e.SurName,
                                            e.InternationalId,
                                            CASE
                                                WHEN et.Id = 1 THEN r.FixedSalaryAmount -- Tip 1 için sabit maaş
                                                WHEN et.Id = 2 THEN r.DailyAmount * ewdoh.WorkingDayOrHour -- Tip 2 için (günlük ücret * WorkingDayOrHour)
                                                WHEN et.Id = 3 THEN (r.FixedSalaryAmount + r.OvertimeAmount) * ewdoh.WorkingDayOrHour -- Tip 3 için ((sabit maaş + fazla mesai ücreti) * WorkingDayOrHour)
                                                ELSE NULL
                                            END AS [Salary]
                                        FROM
                                            Employees AS e
                                        INNER JOIN
                                            EmployeeTypes AS et ON e.EmployeeTypeId = et.Id
                                        INNER JOIN
                                            Revenues AS r ON 
                                                r.PeriodStart <= @CurrentDate AND
                                                r.PeriodEnd >= @CurrentDate
                                        LEFT JOIN
                                            EmployeeWorkingDayOrHour AS ewdoh ON e.Id = ewdoh.EmployeeId
                                    END"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_CalculateAllSalary");
        }

    }
}
