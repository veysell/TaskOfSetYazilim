
using DataAccess.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Ahmet", SurName = "Dur", EmployeeTypeId = 1, InternationalId = "12345678911" },
                new Employee { Id = 2, Name = "Mehmet", SurName = "Yılmaz", EmployeeTypeId = 2, InternationalId = "98765432100" },
                new Employee { Id = 3, Name = "Ayşe", SurName = "Yıldız", EmployeeTypeId = 3, InternationalId = "45678912300" }
                );
            modelBuilder.Entity<EmployeeType>().HasData(
                new EmployeeType { Id=1, Name="Tip 1"},
                new EmployeeType { Id=2, Name="Tip 2"},
                new EmployeeType { Id=3, Name="Tip 3"}
                );
            modelBuilder.Entity<Revenue>().HasData(
                new Revenue {Id=1, Name = "Ocak-Mayıs Dönemi Ödeme Miktarları", FixedSalaryAmount = 25000.00m, OvertimeAmount = 500.50m, DailyAmount = 1500.75m, PeriodStart = new DateTime(2024, 01, 1), PeriodEnd = new DateTime(2024, 05, 1) }
                );
        }
    }
}
