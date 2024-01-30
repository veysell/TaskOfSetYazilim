using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class _sp : Migration
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
                                                WHEN et.Id = 1 THEN r.FixedSalaryAmount 
                                                WHEN et.Id = 2 THEN r.DailyAmount * ISNULL(SUM(ewdoh.WorkingDayOrHour),0) 
                                                WHEN et.Id = 3 THEN (r.FixedSalaryAmount + r.OvertimeAmount* ISNULL(SUM(ewdoh.WorkingDayOrHour),0)) 
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
                                        GROUP BY
                                            e.Name, e.SurName, e.InternationalId, et.Id, r.FixedSalaryAmount, r.DailyAmount, r.OvertimeAmount; 
                                    END"
            );

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
                                                WHEN et.Id = 2 THEN r.DailyAmount * ISNULL(SUM(ewdoh.WorkingDayOrHour),0) -- Toplamı al
                                                WHEN et.Id = 3 THEN (r.FixedSalaryAmount + r.OvertimeAmount * ISNULL(SUM(ewdoh.WorkingDayOrHour),0)) 
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
                                            e.Id = @EmployeeId
                                        GROUP BY
                                            e.Name, e.SurName, e.InternationalId, et.Id, r.FixedSalaryAmount, r.DailyAmount, r.OvertimeAmount; -- Gruplama alanları
                                    END
                                    "
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_CalculateAllSalary");

            migrationBuilder.Sql($@"DROP PROC sp_GetSalaryByEmployeeId");
        }
    }
}
