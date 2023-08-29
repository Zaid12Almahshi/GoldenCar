using Domain.AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using GoldenCar.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.UnitWork;
using static Domain.Common.CommonClass;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoldenCar.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; }
        public IAuthentication<UsersModel> Authentication { get; }

        public UsersController(IUnitOfWork unitOfWork,IAuthentication<UsersModel> authentication)
        {
            UnitOfWork = unitOfWork;
            Authentication = authentication;
        }
        [HttpPost(nameof(GetUserList))]
        public async Task<ResponseStandardJsonApi> GetUserList()
        {
            var responseapi=new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var obj = await UnitOfWork.Users.GetList(new Users());
                var newdata = Mapper.Map<IList<UsersModel>>(obj);
                if (newdata.Count>0)
                {
                    responseapi.Message = "Show data";
                    responseapi.Code = Ok().StatusCode;
                    responseapi.Success = true;
                    responseapi.Result=newdata;

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
                responseapi.Code = NotFound().StatusCode;
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };
            }
            return responseapi;
        }
        [HttpPost(nameof(UserLogin))]
        public async Task<ResponseStandardJsonApi> UserLogin(UsrerLoginModel user)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper=AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Users>(user);
                var User=await UnitOfWork.Users.GetUserNameAndPassword(newdata);
                if (User !=null)
                {
                    var Userdata = Mapper.Map<UsersModel>(User);
                    Userdata.Token = Authentication.GetJsonWebToken(Userdata);
                    responseapi.Message = "Login";
                    responseapi.Code = Ok().StatusCode;
                    responseapi.Success = true;
                    responseapi.Result = Userdata;
                }
                else
                {
                    responseapi.Message = "Not found User";
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

        [HttpPost(nameof(UserRegister))]
        public async Task<ResponseStandardJsonApi> UserRegister(UserRegisterModel user)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata=Mapper.Map<Users>(user);
                await UnitOfWork.Users.Add(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.CreateId = UserInfo.nameid;
                responseapi.Message = "Add successfully";
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


        [HttpPost(nameof(UserUpdate))]
        public async Task<ResponseStandardJsonApi> UserUpdate(UserUpdateModel user)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Users>(user);
                await UnitOfWork.Users.Update(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "Update successfully";
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
        [HttpPost(nameof(GetUserWhereId))]
        public async Task<ResponseStandardJsonApi> GetUserWhereId(GetUserByIdModel user)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper=AutoMapperConfiguration.CreateMapper();
                var obj=Mapper.Map<Users>(user);
                var data=await UnitOfWork.Users.GetById(obj);
                var newdata=Mapper.Map<UsersModel>(data);
                if (newdata !=null)
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
                ;
            }
            catch (Exception ex)
            {
                responseapi.Message = ex.Message;
                responseapi.Code = NotFound().StatusCode;
                responseapi.Success = false;
                responseapi.Result = new NullColumns[] { };
            }

            return responseapi;

        }

        [HttpPost(nameof(UserDelete))]
        public async Task<ResponseStandardJsonApi> UserDelete(UserDeleteModel user)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Users>(user);
                await UnitOfWork.Users.Delete(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "delete successfully";
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


        [HttpPost(nameof(UserActive))]
        public async Task<ResponseStandardJsonApi> UserActive(UserActiveModel user)
        {
            var responseapi = new ResponseStandardJsonApi();
            try
            {
                var Mapper = AutoMapperConfiguration.CreateMapper();
                var newdata = Mapper.Map<Users>(user);
                await UnitOfWork.Users.Delete(newdata);
                var Token = Request.Headers["Authorization"].ToString();
                var UserInfo = InformationToken.GetInfoUser(Token);
                newdata.EditId = UserInfo.nameid;
                responseapi.Message = "Active successfully";
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
