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
    public class RevenueController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public RevenueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Getir_GelirMiktarSabitleri")]
        public IActionResult Get()
        {
            var revenueList = _unitOfWork.Revenue.GetAll();
            return Ok(revenueList);
        }


        [HttpPut("Guncelle_GelirMiktarSabitleri")]
        public ApiResponseModel<Revenue> UpdateRevenues(RevenueModel model)
        {
            var revenueItem=_unitOfWork.Revenue.Get(x=>x.Id==model.Id);
            if (revenueItem!=null)
            {
                var updatedItem = new Revenue
                {
                    Id = model.Id,
                    DailyAmount = model.DailyAmount,
                    FixedSalaryAmount = model.FixedSalaryAmount,
                    Name = revenueItem.Name,
                    OvertimeAmount = model.OvertimeAmount,
                    PeriodStart = revenueItem.PeriodStart,
                    PeriodEnd = revenueItem.PeriodEnd
                };
                _unitOfWork.Revenue.Update(updatedItem);
                return new ApiResponseModel<Revenue> {Data=updatedItem,IsSuccess=true,Message="Bilgiler Güncellendi." };
            }
            return new ApiResponseModel<Revenue> { IsSuccess=false,Message="Id değerini kontrol ediniz."};
        }
    }
}
