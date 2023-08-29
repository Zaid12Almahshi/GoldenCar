using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositoy.Constants;
using Repositoy.Repositories;
using Services.Interfaces.IRental;
using Services.Services.Rentals;
using Services.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceRegistration
    {
        public static void AddInfraStructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IPaymentService<Payment>,PaymentService>();
            services.AddScoped<IVecihleService<Vecihle>,VecihleService>();
            services.AddScoped<IUsersService<Users>, UsersService>();
            services.AddScoped<IRentalService<Rental>,RentalService>();


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IReopsitory<>), typeof(Repository<>));
            CommonConstants.ConnectionString = configuration.GetConnectionString("Sqlcon");



        }
    }
}
