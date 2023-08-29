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
    [Authorize(AuthenticationSchemes =Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class RentalController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; }

        public RentalController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        [HttpPost(nameof(GetRentalList))]
        public async Task<ResponseStandardJsonApi> GetRentalList()
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var obj = await UnitOfWork.Rental.GetList(new Rental());
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<IList<RentalListModel>>(obj);
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
                    responseapi.Result =new  NullColumns[]{ };

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

        [HttpPost(nameof(GetRentalAdd))]
        public async Task<ResponseStandardJsonApi> GetRentalAdd(AddRentalModel rental)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper=AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Rental>(rental);
                await UnitOfWork.Rental.Add(newdata);
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
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }

        [HttpPost(nameof(GetRentalUpdate))]
        public async Task<ResponseStandardJsonApi> GetRentalUpdate(UpdateRentalModel rental)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata=Mapper.Map<Rental>(rental);
                await UnitOfWork.Rental.Update(newdata);
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
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;

        }

        [HttpPost(nameof(GetRentalWhereId))]
        public async Task<ResponseStandardJsonApi> GetRentalWhereId(GetRentalByIdModel rental)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var date = Mapper.Map<Rental>(rental);
                var obj = await UnitOfWork.Rental.GetById(date);
                var newdata = Mapper.Map<RentalListModel>(obj);


                if (newdata != null)
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
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }

        [HttpPost(nameof(GetRentalDelete))]
        public async Task<ResponseStandardJsonApi> GetRentalDelete(DeleteRentalModel rental)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Rental>(rental);
                await UnitOfWork.Rental.Delete(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "delete Successfully";
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = newdata;

            }
            catch (Exception ex)
            {
                responseapi.Message = ex.Message;
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
        [HttpPost(nameof(GetRentalActive))]
        public async Task<ResponseStandardJsonApi> GetRentalActive(ActiveRentalModel rental)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Rental>(rental);
                await UnitOfWork.Rental.Active(newdata);
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
                responseapi.Code = Ok().StatusCode;
                responseapi.Success = true;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
    }
}
