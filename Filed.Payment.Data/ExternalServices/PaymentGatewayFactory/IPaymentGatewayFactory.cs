using Filed.PaymentProcessor.Core.PaymentGateway;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGatewayFactory
{
    public interface IPaymentGatewayFactory
    {
        IPaymentGateway CreatePaymentGatewayService(decimal amount);
    }
}
