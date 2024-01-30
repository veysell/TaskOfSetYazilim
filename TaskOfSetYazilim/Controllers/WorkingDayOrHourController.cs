using DataAccess.Entities;
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
    public class WorkingDayOrHourController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WorkingDayOrHourController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpPost("Getir_CalisanMesaiMikrariById")]
        public ApiResponseModel<WorkingTimeModel> Get(int CalisanId)
        {
            var data = _unitOfWork.WorkingTime.Include(x => x.EmployeeId == CalisanId, x => x.Employee);
            if (data.Count()>0)
            {
                var item = data.FirstOrDefault();
                var responseData=new WorkingTimeModel
                {
                    EmployeeId = item.Employee.Id,
                    EmployeeName=item.Employee.Name,
                    EmployeeSurname=item.Employee.SurName,
                    Time=data.Sum(x=>x.WorkingDayOrHour)
                };
                return new ApiResponseModel<WorkingTimeModel> { Data=responseData};
            }
            return new ApiResponseModel<WorkingTimeModel> { Message="Mesai bilgisi bulunamadı."};
        }

        [HttpPost("Ekle_CalisanMesaiMikrariById")]
        public IActionResult Add(WorkingTimeAddModel model)
        {
            var addItem = new EmployeeWorkingDayOrHour
            {
               EmployeeId=model.EmployeeId,
               WorkingDayOrHour=model.WorkTime,
            };
            var IsExist = _unitOfWork.Employee.GetAll().FirstOrDefault(x => x.Id == model.EmployeeId);
            if (IsExist != null)
                _unitOfWork.WorkingTime.Add(addItem);
            else
                return BadRequest("Çalışan Id'yi kontrol edin.");

            return Ok("Çalışan için mesai bilgisi eklendi.");
        }
    }
}
