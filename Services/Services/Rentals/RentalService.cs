using Domain.Entities;
using Repositoy.Repositories;
using Services.Interfaces.IRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Rentals
{
    public class RentalService : IRentalService<Rental>
    {
        public IReopsitory<Rental> Repository { get; }

        public RentalService(IReopsitory<Rental> repository)
        {
            Repository = repository;
        }


        public async Task Active(Rental entity)
        {
            var obj = new
            {
                RentalId=entity.RentalId,
                EditId=entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetRentalActive", obj);//tam
        }

        public async Task Add(Rental entity)
        {
            var obj = new
            {
                UsersId=entity.UsersId,
                VecihleId=entity.VecihleId,
                Satrt_Date=entity.Satrt_Date,
                End_Date=entity.End_Date,
                Total_Cost=entity.Total_Cost,
                PaymentId=entity.PaymentId,
                CreateId=entity.CreateId,
            };
            await Repository.ExecCommand("Sp_GetRentalInsert", obj);//tam
        }

        public async Task Delete(Rental entity)
        {
            var obj = new
            {
                RentalId = entity.RentalId,
                EditId = entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetRentalDelete", obj);//tam
        }

        public async Task<Rental> GetById(Rental entity)
        {
            var obj= new 
            {
                RentalId = entity.RentalId,
            };
            return await Repository.FindExecCommand("Sp_GetRentalWhereId", obj);//tam
        }

        public async Task<List<Rental>> GetList(Rental entity)
        {
            var obj = new
            {

            };
            return await Repository.ListData("Sp_GetAllRental", obj);//tam
        }

        public async Task Update(Rental entity)
        {
            var obj = new
            {
                RentalId = entity.RentalId,
                UsersId = entity.UsersId,
                VecihleId = entity.VecihleId,
                Satrt_Date = entity.Satrt_Date,
                End_Date = entity.End_Date,
                Total_Cost = entity.Total_Cost,
                PaymentId = entity.PaymentId,
                EditId = entity.EditId,

            };
            await Repository.ExecCommand("Sp_GetRentalUpdate", obj);//tam
        }
    }
}
