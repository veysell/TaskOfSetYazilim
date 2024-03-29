﻿using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOfSetYazilim.Models;

namespace TaskOfSetYazilim.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet("Getir_CalisanListesi")]
        public IActionResult Get()
        {
            var employee = _unitOfWork.Employee.GetAll();
            return Ok(employee);
        }

        [HttpGet("Getir_CalisanlarBordro")]
        public IActionResult GetAllSalaryInfos()
        {
            var employee = _unitOfWork.Employee.GetAllSalaryList();

            return Ok(employee);
        }

        [HttpPost("Getir_CalisanBordro")]
        public IActionResult GetAllSalaryInfos(int EmployeeId)
        {
            var IsValidEmployee = _unitOfWork.Employee.Get(x => x.Id == EmployeeId);
            if (IsValidEmployee == null)
            {
                return BadRequest("Geçersiz Çalışan Id");
            }
            var employee = _unitOfWork.Employee.GetSalaryInfo(EmployeeId);

            return Ok(employee);
        }


        [HttpPost("Ekle_Calisan")]
        public ApiResponseModel<Employee> AddEmployee([FromBody] EmployeeAddModel model)
        {
            var addItem = new Employee
            {
                Name = model.Name,
                SurName = model.SurName,
                InternationalId = model.InternationalId,
                EmployeeTypeId = model.CalisanTipiId
            };
            var IsExist = _unitOfWork.Employee.GetAll().FirstOrDefault(x => x.InternationalId == addItem.InternationalId);
            if (IsExist != null)
                return new ApiResponseModel<Employee> { Message = "Çalışan mevcut", IsSuccess = false };
            else
                _unitOfWork.Employee.Add(addItem);

            return new ApiResponseModel<Employee> { Message = "Çalışan eklendi" };
        }
    }
}
