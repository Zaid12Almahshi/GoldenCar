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
    public class PaymentService : IPaymentService<Payment>
    {
        public IReopsitory<Payment> Repository { get; }

        public PaymentService(IReopsitory<Payment> repository)
        {
            Repository = repository;
        }


        public async Task Active(Payment entity)
        {
            var obj = new
            {
                PaymentId=entity.PaymentId,
                EditId=entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetPaymentActive", obj);//tam
        }

        public async Task Add(Payment entity)
        {
            var obj = new
            {
                Cardholder_Name=entity.Cardholder_Name,
                Card_Number=entity.Card_Number,
                Expiry_Date=entity.Expiry_Date,
                CVV=entity.CVV,
                CreateId= entity.CreateId,
            };
            await Repository.ExecCommand("Sp_GetPaymentInsert", obj);//tam
        }

        public async Task Delete(Payment entity)
        {
            var obj = new
            {
                PaymentId=entity.PaymentId,
                EditId=entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetPaymentDalete", obj);//tam
        }

        public async Task<Payment> GetById(Payment entity)
        {
            var obj = new
            {
                PaymentId = entity.PaymentId,

            };
            return await Repository.FindExecCommand("Sp_GetPaymentWhereId", obj);//tam
        }

        public async Task<List<Payment>> GetList(Payment entity)
        {
            var obj = new
            {

            };
            return await Repository.ListData("Sp_GetAllPayment", obj);//tam

        }

        public async Task Update(Payment entity)
        {
            var obj = new
            {
                PaymentId= entity.PaymentId,
                Cardholder_Name= entity.Cardholder_Name,
                Card_Number= entity.Card_Number,
                Expiry_Date= entity.Expiry_Date,
                CVV=entity.CVV,
                EditId= entity.EditId,
            };
            await Repository.ExecCommand("Sp_GetPaymentUpdate", obj);//tam
        }
    }
}
