using System;

namespace Filed.PaymentProcessor.Core.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string CardHolder { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public PaymentState PaymentState { get; set; }
    }
}
