using System;

namespace Filed.PaymentProcessor.Core.Payments
{
    public class PaymentState
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }

    }
}
