using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class PaymentModel
    {
        public string Cardholder_Name { get; set; } = string.Empty;
        public int Card_Number { get; set; }
        public string Expiry_Date { get; set; } = string.Empty;
        public int CVV { get; set; }
    }
    public class AddPaymentModel
    {
        public string Cardholder_Name { get; set; } = string.Empty;
        public int Card_Number { get; set; }
        public string Expiry_Date { get; set; } = string.Empty;
        public int CVV { get; set; }
        public string CreateId { get; set; } = string.Empty;
    }
    public class UpdatePaymentModel
    {
        public string PaymentId { get; set; } = string.Empty;
        public string Cardholder_Name { get; set; } = string.Empty;
        public int Card_Number { get; set; }
        public string Expiry_Date { get; set; } = string.Empty;
        public int CVV { get; set; }
        public string EditId { get; set; } = string.Empty;
    }
    public class DeletePaymentModel
    {
        public string PaymentId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
    public class GetPaymentByIdModel
    {
        public string PaymentId { get; set; } = string.Empty;
    }
    public class ActivePaymentModel
    {
        public string PaymentId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
}
