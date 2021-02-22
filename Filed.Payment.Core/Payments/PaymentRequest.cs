using System;

namespace Filed.PaymentProcessor.Core.Payments
{
    public class PaymentRequest
    {
        public string CardHolder { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
    }
}
