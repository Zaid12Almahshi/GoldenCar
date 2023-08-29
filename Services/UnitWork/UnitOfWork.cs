using Domain.Entities;
using Services.Interfaces.IRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUsersService<Users> users,IRentalService<Rental> rental,
            IPaymentService<Payment> payment,IVecihleService<Vecihle> vecihle )
        {
            Users = users;
            Rental = rental;
            Payment = payment;
            Vecihle = vecihle;
        }

        public IUsersService<Users> Users { get; }
        public IRentalService<Rental> Rental { get; }
        public IPaymentService<Payment> Payment { get; }
        public IVecihleService<Vecihle> Vecihle { get; }
    }
}
