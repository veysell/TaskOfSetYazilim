﻿// <auto-generated />
using System;
using DataAccess.mssql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("InternationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeTypeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeTypeId = 1,
                            InternationalId = "12345678911",
                            IsActive = true,
                            Name = "Ahmet",
                            SurName = "Dur"
                        },
                        new
                        {
                            Id = 2,
                            EmployeeTypeId = 1,
                            InternationalId = "12444678911",
                            IsActive = true,
                            Name = "Ahmet",
                            SurName = "Akça"
                        },
                        new
                        {
                            Id = 3,
                            EmployeeTypeId = 2,
                            InternationalId = "98765432100",
                            IsActive = true,
                            Name = "Mehmet",
                            SurName = "Yılmaz"
                        },
                        new
                        {
                            Id = 4,
                            EmployeeTypeId = 2,
                            InternationalId = "98765552100",
                            IsActive = true,
                            Name = "Mehmet",
                            SurName = "Tuna"
                        },
                        new
                        {
                            Id = 5,
                            EmployeeTypeId = 3,
                            InternationalId = "45678912300",
                            IsActive = true,
                            Name = "Ayşe",
                            SurName = "Yıldız"
                        },
                        new
                        {
                            Id = 6,
                            EmployeeTypeId = 3,
                            InternationalId = "41118912300",
                            IsActive = true,
                            Name = "Ayşe",
                            SurName = "Yalnız"
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Tip 1"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Tip 2"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Tip 3"
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeWorkingDayOrHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("WorkingDayOrHour")
                        .HasColumnType("decimal(4,1)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeWorkingDayOrHour");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 3,
                            IsActive = true,
                            WorkingDayOrHour = 2m
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 4,
                            IsActive = true,
                            WorkingDayOrHour = 2m
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 5,
                            IsActive = true,
                            WorkingDayOrHour = 2m
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 6,
                            IsActive = true,
                            WorkingDayOrHour = 2m
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Revenue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("DailyAmount")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal>("FixedSalaryAmount")
                        .HasColumnType("decimal(7,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("OvertimeAmount")
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime>("PeriodEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Revenues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyAmount = 1500.75m,
                            FixedSalaryAmount = 25000.00m,
                            IsActive = true,
                            Name = "Ocak-Mayıs Dönemi Ödeme Miktarları",
                            OvertimeAmount = 500.50m,
                            PeriodEnd = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PeriodStart = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Veysel",
                            Password = "user",
                            UserName = "super"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.SalaryList", b =>
                {
                    b.Property<string>("InternationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SalaryInfos");
                });

            modelBuilder.Entity("DataAccess.Entities.Employee", b =>
                {
                    b.HasOne("DataAccess.Entities.EmployeeType", "EmployeeType")
                        .WithMany()
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeType");
                });

            modelBuilder.Entity("DataAccess.Entities.EmployeeWorkingDayOrHour", b =>
                {
                    b.HasOne("DataAccess.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
