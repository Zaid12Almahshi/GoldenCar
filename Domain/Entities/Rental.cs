using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rental : BaseEntity
    {
        public string RentalId { get; set; } = string.Empty;
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
}
