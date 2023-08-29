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
    public class VecihleController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; }

        public VecihleController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpPost(nameof(GetVecihleList))]
        public async Task<ResponseStandardJsonApi> GetVecihleList()
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var obj = await UnitOfWork.Vecihle.GetList(new Vecihle());
                var newdata=Mapper.Map<IList<VecihleModel>>(obj);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                if (newdata.Count>0) 
                {
                    responseapi.Message = "Show data";
                    responseapi.Code = Ok().StatusCode;
                    responseapi.Success = true;
                    responseapi.Result = newdata;
                        
                
                }
                else
                {
                    responseapi.Message = "No data";
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

        [HttpPost(nameof(GetVecihleAdd))]
        public async Task<ResponseStandardJsonApi> GetVecihleAdd(AddVecihleModel vecihle)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Vecihle>(vecihle);
                await UnitOfWork.Vecihle.Add(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo=InformationToken.GetInfoUser(Token);
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
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }

        [HttpPost(nameof(GetVecihleUpdate))]
        public async Task<ResponseStandardJsonApi> GetVecihleUpdate(UpdateVecihleModel vecihle)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Vecihle>(vecihle);
                await UnitOfWork.Vecihle.Update(newdata);
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
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }

        [HttpPost(nameof(GetVeciheWhereId))]
        public async Task<ResponseStandardJsonApi> GetVeciheWhereId(GetVecihlByIdModel vecihle)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper=AutoMapperConfiguration.CreateMapper();
                var data = Mapper.Map<Vecihle>(vecihle);
                var obj = await UnitOfWork.Vecihle.GetById(data);
                var newdata = Mapper.Map<VecihleModel>(obj);
                if (newdata!=null)
                {
                    responseapi.Message = "Show data";
                    responseapi.Code = Ok().StatusCode;
                    responseapi.Success = true;
                    responseapi.Result = newdata;


                }
                else
                {
                    responseapi.Message = "No data";
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

        [HttpPost(nameof(GetVecihleDelete))]
        public async Task<ResponseStandardJsonApi> GetVecihleDelete(DeleteVecihleModel vecihle)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Vecihle>(vecihle);
                await UnitOfWork.Vecihle.Delete(newdata);
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
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
        [HttpPost(nameof(GetVecihleActive))]
        public async Task<ResponseStandardJsonApi> GetVecihleActive(ActiveVecihleModel vecihle)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Vecihle>(vecihle);
                await UnitOfWork.Vecihle.Active(newdata);
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
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
    }
}
