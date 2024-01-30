
using DataAccess.Entities;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.mssql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<EmployeeWorkingDayOrHour> EmployeeWorkingDayOrHour { get; set; }
        public DbSet<SalaryList> SalaryInfos { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalaryList>().HasNoKey();

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ahmet", SurName = "Dur", EmployeeTypeId = 1, InternationalId = "12345678911" },
                new Employee { Id = 2, Name = "Ahmet", SurName = "Akça", EmployeeTypeId = 1, InternationalId = "12444678911" },
                new Employee { Id = 3, Name = "Mehmet", SurName = "Yılmaz", EmployeeTypeId = 2, InternationalId = "98765432100" },
                new Employee { Id = 4, Name = "Mehmet", SurName = "Tuna", EmployeeTypeId = 2, InternationalId = "98765552100" },
                new Employee { Id = 5, Name = "Ayşe", SurName = "Yıldız", EmployeeTypeId = 3, InternationalId = "45678912300" },
                new Employee { Id = 6, Name = "Ayşe", SurName = "Yalnız", EmployeeTypeId = 3, InternationalId = "41118912300" }
                );
            modelBuilder.Entity<EmployeeType>().HasData(
                new EmployeeType { Id = 1, Name = "Tip 1" },
                new EmployeeType { Id = 2, Name = "Tip 2" },
                new EmployeeType { Id = 3, Name = "Tip 3" }
                );
            modelBuilder.Entity<EmployeeWorkingDayOrHour>().HasData(
                new EmployeeWorkingDayOrHour { Id = 1, EmployeeId = 3, WorkingDayOrHour = 2 },
                new EmployeeWorkingDayOrHour { Id = 2, EmployeeId = 4, WorkingDayOrHour = 2 },
                new EmployeeWorkingDayOrHour { Id = 3, EmployeeId = 5, WorkingDayOrHour = 2 },
                new EmployeeWorkingDayOrHour { Id = 4, EmployeeId = 6, WorkingDayOrHour = 2 }
                );
            modelBuilder.Entity<Revenue>().HasData(
                new Revenue { Id = 1, Name = "Ocak-Mayıs Dönemi Ödeme Miktarları", FixedSalaryAmount = 25000.00m, OvertimeAmount = 500.50m, DailyAmount = 1500.75m, PeriodStart = new DateTime(2024, 01, 1), PeriodEnd = new DateTime(2024, 05, 1) }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Veysel", UserName = "super", Password = "user" }
                );
        }
    }
}
