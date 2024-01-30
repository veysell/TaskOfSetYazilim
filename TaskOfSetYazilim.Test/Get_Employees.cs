using DataAccess.Entities;
using DataAccess.mssql;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TaskOfSetYazilim.Controllers;

namespace TaskOfSetYazilim.Test
{
    public class Tests
    {
        EmployeeController _controller;
        IUnitOfWork _unitOfWork;
        
        [SetUp]
        public void Setup()
        {
            var mockUnitOfWork = new IUnitOfWork;
            mockUnitOfWork.Setup(u => u.Employee.GetAll(x=>x.Id==1)).Returns(new List<Employee> { new Employee { Id = 1, Name = "Test Employee",SurName="test",EmployeeTypeId=1, InternationalId="1212121212",IsActive=true} });

            _unitOfWork = mockUnitOfWork.Object;
        }

        [Test]
        public void Get_Employees()
        {
            var controller = new EmployeeController(_unitOfWork);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var employees = okResult.Value as List<Employee>;
            Assert.IsNotNull(employees);
            Assert.AreEqual(1, employees.Count);
        }
    }
}