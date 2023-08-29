using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment:BaseEntity
    {
        public string PaymentId { get; set; } = string.Empty;
        public string Cardholder_Name { get; set; } = string.Empty;
        public int Card_Number { get; set; }
        public string Expiry_Date { get; set; }=string.Empty;
        public int CVV { get; set; }
    }
}
