using AutoMapper;
using Domain.Entities;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {

            var MapConfig=new MapperConfiguration(M=>
            {
                M.CreateMap<Users, UsersModel>().ReverseMap();
                M.CreateMap<Users, UsrerLoginModel>().ReverseMap();
                M.CreateMap<Users, UserRegisterModel>().ReverseMap();
                M.CreateMap<Users, GetUserByIdModel>().ReverseMap();
                M.CreateMap<Users, UserUpdateModel>().ReverseMap();
                M.CreateMap<Users, UserDeleteModel>().ReverseMap();
                M.CreateMap<Users, UserActiveModel>().ReverseMap();



                M.CreateMap<Rental, RentalModel>().ReverseMap();
                M.CreateMap<Rental, RentalListModel>().ReverseMap();
                M.CreateMap<Rental, AddRentalModel>().ReverseMap();
                M.CreateMap<Rental, UpdateRentalModel>().ReverseMap();
                M.CreateMap<Rental, GetRentalByIdModel>().ReverseMap();
                M.CreateMap<Rental, DeleteRentalModel>().ReverseMap();
                M.CreateMap<Rental, ActiveRentalModel>().ReverseMap();



                M.CreateMap<Payment, PaymentModel>().ReverseMap();
                M.CreateMap<Payment, AddPaymentModel>().ReverseMap();
                M.CreateMap<Payment, UpdatePaymentModel>().ReverseMap();
                M.CreateMap<Payment, DeletePaymentModel>().ReverseMap();
                M.CreateMap<Payment, GetPaymentByIdModel>().ReverseMap();
                M.CreateMap<Payment, ActivePaymentModel>().ReverseMap();



                M.CreateMap<Vecihle, VecihleModel>().ReverseMap();
                M.CreateMap<Vecihle, AddVecihleModel>().ReverseMap();
                M.CreateMap<Vecihle, UpdateVecihleModel>().ReverseMap();
                M.CreateMap<Vecihle, GetVecihlByIdModel>().ReverseMap();
                M.CreateMap<Vecihle, DeleteVecihleModel>().ReverseMap();
                M.CreateMap<Vecihle, ActiveVecihleModel>().ReverseMap();



            });
            return MapConfig.CreateMapper();

        }

    }
}
