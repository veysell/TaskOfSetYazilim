using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class sp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE PROCEDURE sp_GetSalaryByEmployeeId
                                        @EmployeeId INT
                                    AS
                                    BEGIN
                                        DECLARE @CurrentDate DATE = GETDATE();

                                        SELECT
                                            e.Name,
                                            e.SurName,
                                            e.InternationalId,
                                            CASE
                                                WHEN et.Id = 1 THEN r.FixedSalaryAmount 
                                                WHEN et.Id = 2 THEN r.DailyAmount * ewdoh.WorkingDayOrHour
                                                WHEN et.Id = 3 THEN (r.FixedSalaryAmount + r.OvertimeAmount* ewdoh.WorkingDayOrHour) 
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
                                        WHERE
                                            e.Id = @EmployeeId;
                                    END"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_GetSalaryByEmployeeId");
        }

    }
}
