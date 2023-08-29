using Domain.Entities;
using Repositoy.Repositories;
using Services.Interfaces.IRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Rentals
{
    public class UsersService : IUsersService<Users>
    {
        public IReopsitory<Users> Repository { get; }
        public UsersService(IReopsitory<Users> repository)
        {
            Repository = repository;
        }
        public async Task Active(Users entity)
        {
            var obj = new
            {
                UsersId=entity.UsersId,
                EditId=entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetUsersActive", obj);//tam
        }

        public async Task Add(Users entity)
        {
            var obj = new
            {
                First_Name=entity.First_Name,
                Last_Name=entity.Last_Name,
                Gender=entity.Gender,
                Address=entity.Address,
                Phone_No=entity.Phone_No,
                Email=entity.Email,
                Password=entity.Password,

            };
            await Repository.ExecCommand("Sp_GetUsersRegister", obj);//tam
        }

        public async Task Delete(Users entity)
        {
            var obj = new
            {
                UsersId = entity.UsersId,
                EditId = entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetUsersDelete", obj);//tam
        }

        public async Task<Users> GetById(Users entity)
        {
            var obj = new
            {
                UsersId = entity.UsersId,
            };
            return await Repository.FindExecCommand("Sp_GetUsersWhereId", obj);//tam
        }

        public async Task<List<Users>> GetList(Users entity)
        {
            var obj = new
            {

            };
            return await Repository.ListData("Sp_GetAllUsers", obj); //tam
        }

        public async Task<Users> GetUserNameAndPassword(Users entity)
        {
            var obj = new
            {
                Email = entity.Email,
                Password = entity.Password,
            };
            return await Repository.FindExecCommand("Sp_GetUsersLogin", obj);//tam
        }

        public async Task Update(Users entity)
        {
            var obj = new
            {
                UsersId = entity.UsersId,
                First_Name = entity.First_Name,
                Last_Name = entity.Last_Name,
                Gender = entity.Gender,
                Address = entity.Address,
                Phone_No = entity.Phone_No,
                Email = entity.Email,
                Password = entity.Password,
                EditId = entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetUsersUpdate", obj);//tam
        }
    }
}
