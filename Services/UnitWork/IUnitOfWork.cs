using Domain.Entities;
using Services.Interfaces.IRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitWork
{
    public interface IUnitOfWork
    {
        public IPaymentService<Payment> Payment { get; }
        public IUsersService<Users> Users { get; }
        public IVecihleService<Vecihle> Vecihle { get; }
        public IRentalService<Rental> Rental { get; }
    }
}
