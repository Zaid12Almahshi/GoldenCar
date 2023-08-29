using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class RentalModel
    {
        public string UsersId { get; set; } = string.Empty;
        public Users? Users { get; set; }
        public string VecihleId { get; set; } = string.Empty;
        public Vecihle? Vecihle { get; set; }
        public DateTime Satrt_Date { get; set; }
        public DateTime End_Date { get; set; }
        public double Total_Cost { get; set; }
        public string PaymentId { get; set; } = string.Empty;
        public Payment? Payment { get; set; }
    }
    
    public class RentalListModel
    {
        public string UsersId { get; set; } = string.Empty;
        public string VecihleId { get; set; } = string.Empty;
        public DateTime Satrt_Date { get; set; }
        public DateTime End_Date { get; set; }
        public double Total_Cost { get; set; }
        public string PaymentId { get; set; } = string.Empty;
    }
    public class AddRentalModel
    {
        public string UsersId { get; set; } = string.Empty;
        public string VecihleId { get; set; } = string.Empty;
        public DateTime Satrt_Date { get; set; }
        public DateTime End_Date { get; set; }
        public double Total_Cost { get; set; }
        public string PaymentId { get; set; } = string.Empty;
        public string CreateId { get; set; } = string.Empty;

    }
    public class UpdateRentalModel
    {
        public string RentalId { get; set; } = string.Empty;
        public string UsersId { get; set; } = string.Empty;
        public string VecihleId { get; set; } = string.Empty;
        public DateTime Satrt_Date { get; set; }
        public DateTime End_Date { get; set; }
        public double Total_Cost { get; set; }
        public string PaymentId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;

    }
    public class GetRentalByIdModel
    {
        public string RentalId { get; set; } = string.Empty;

    }
    public class DeleteRentalModel
    {
        public string RentalId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
    
    public class ActiveRentalModel
    {
        public string RentalId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
}
