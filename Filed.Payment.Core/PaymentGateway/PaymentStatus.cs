namespace Filed.PaymentProcessor.Core.PaymentGateway
{
    public enum PaymentStatus
    {
        Unknown = 0,
        Pending = 1,
        Processed = 2,
        Failed = 3,
        Unavailable = 4
    }
}
