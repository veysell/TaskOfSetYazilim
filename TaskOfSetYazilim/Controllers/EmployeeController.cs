using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOfSetYazilim.Models;

namespace TaskOfSetYazilim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var employee = _unitOfWork.Employee.GetAll();
            return Ok(employee);
        }

        [HttpGet("getsalary")]
        public IActionResult GetAllSalaryInfos()
        {
            var employee = _unitOfWork.Employee.GetAllSalaryList();

            return Ok(employee);
        }
    }
}
