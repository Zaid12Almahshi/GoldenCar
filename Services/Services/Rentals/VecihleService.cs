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
    public class VecihleService : IVecihleService<Vecihle>
    {
        public IReopsitory<Vecihle> Repository { get; }
        public VecihleService(IReopsitory<Vecihle> repository)
        {
            Repository = repository;
        }
        public async Task Active(Vecihle entity)
        {
            var obj = new
            {
                VecihleId=entity.VecihleId,
                EditId=entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetVecihleActive", obj);//tam
        }

        public async Task Add(Vecihle entity)
        {
            var obj = new
            {
                Model=entity.Model,
                Year=entity.Year,
                Type=entity.Type,
                Capacity=entity.Capacity,
                Price_Per_Day=entity.Price_Per_Day,
                Location=entity.Location,
                Color=entity.Color,
                Brand=entity.Brand,
                CreateId=entity.CreateId,
            };
            await Repository.ExecCommand("Sp_GetVecihleInsert", obj);//tam
        }

        public async Task Delete(Vecihle entity)
        {
            var obj = new
            {
                VecihleId = entity.VecihleId,
                EditId = entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetVecihleDelete", obj);//tam
        }

        public async Task<Vecihle> GetById(Vecihle entity)
        {
            var obj = new
            {
                VecihleId = entity.VecihleId,
            };
            return await Repository.FindExecCommand("Sp_GetVecihleWhereId", obj);//tam
        }

        public async Task<List<Vecihle>> GetList(Vecihle entity)
        {
            var obj = new
            {

            };
            return await Repository.ListData("Sp_GetAllVecihle", obj);//tam
        }

        public async Task Update(Vecihle entity)
        {
            var obj = new
            {
                VecihleId = entity.VecihleId,
                Model = entity.Model,
                Year = entity.Year,
                Type = entity.Type,
                Capacity = entity.Capacity,
                Price_Per_Day = entity.Price_Per_Day,
                Location = entity.Location,
                Color = entity.Color,
                Brand = entity.Brand,
                EditId = entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetVecihleUpdate", obj);//tam
        }
    }
}
