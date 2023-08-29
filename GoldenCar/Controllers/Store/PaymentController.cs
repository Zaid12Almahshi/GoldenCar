using Domain.AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using GoldenCar.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.UnitWork;
using static Domain.Common.CommonClass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldenCar.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; }

        public PaymentController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        [HttpPost(nameof(GetPaymentList))]
        public async Task <ResponseStandardJsonApi> GetPaymentList()
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var obj = await UnitOfWork.Payment.GetList(new Payment());
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata=Mapper.Map<IList<PaymentModel>>(obj);
                if (newdata.Count>0)
                {
                    responseapi.Message = "Show Data";
                    responseapi.Code = Ok().StatusCode;
                    responseapi.Success = true;
                    responseapi.Result = newdata;
                }
                else
                {
                    responseapi.Message = "No Data";
                    responseapi.Code = NotFound().StatusCode;
                    responseapi.Success = false;
                    responseapi.Result = new NullColumns[] { };
                }


            }
            catch (Exception ex)
            {
                responseapi.Message = ex.Message;
                responseapi.Code = BadRequest().StatusCode;
                responseapi.Success = false;
                responseapi.Result =new NullColumns[] { } ;

            }
            return responseapi;
            
        }


        [HttpPost(nameof(GetPaymentAdd))]
        public async Task<ResponseStandardJsonApi> GetPaymentAdd(AddPaymentModel payment)
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper=AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Payment>(payment);
                await UnitOfWork.Payment.Add(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.CreateId = UserInfo.nameid;
                responseapi.Message = "Add Successfully";
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = newdata;
            }
            catch (Exception ex)
            {

                responseapi.Message = ex.Message;
                responseapi.Code = BadRequest().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
        [HttpPost(nameof(GetPaymentWhereId))]
        public async Task<ResponseStandardJsonApi> GetPaymentWhereId(GetPaymentByIdModel payment)
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var data=Mapper.Map<Payment>(payment);
                var obj =await UnitOfWork.Payment.GetById(data);
                var newdata = Mapper.Map<PaymentModel>(obj);
                if (newdata !=null)
                {
                    responseapi.Message = "Show data";
                    responseapi.Code = Ok().StatusCode;
                    responseapi.Success = true;
                    responseapi.Result = newdata;
                }
                else
                {
                    responseapi.Message = "No Data";
                    responseapi.Code = NotFound().StatusCode;
                    responseapi.Success = false;
                    responseapi.Result = new NullColumns[] { };
                }


            }
            catch (Exception ex)
            {
                responseapi.Message = ex.Message;
                responseapi.Code = BadRequest().StatusCode;
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };

            }
            return responseapi;
        }

        [HttpPost(nameof(GetPaymentUpdate))]
        public async Task<ResponseStandardJsonApi> GetPaymentUpdate(UpdatePaymentModel payment)
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata=Mapper.Map<Payment> (payment);
                await UnitOfWork.Payment.Update(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "Update Successfully";
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = newdata;

            }
            catch (Exception ex)
            {

                responseapi.Message = ex.Message;
                responseapi.Code = BadRequest().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }

        [HttpPost(nameof(GetPaymentDelete))]
        public async Task<ResponseStandardJsonApi> GetPaymentDelete(DeletePaymentModel payment)
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper=AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Payment>(payment);
                await UnitOfWork.Payment.Delete(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "Delete Successfully";
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = newdata;



            }
            catch (Exception ex)
            {

                responseapi.Message = ex.Message;
                responseapi.Code = BadRequest().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }

        [HttpPost(nameof(GetPaymentActive))]
        public async Task<ResponseStandardJsonApi> GetPaymentActive(ActivePaymentModel payment)
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Payment>(payment);
                await UnitOfWork.Payment.Active(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "Active Successfully";
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = newdata;



            }
            catch (Exception ex)
            {

                responseapi.Message = ex.Message;
                responseapi.Code = BadRequest().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
            
        
    }
}
