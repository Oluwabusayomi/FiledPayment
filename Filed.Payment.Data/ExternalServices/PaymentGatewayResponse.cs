using Filed.PaymentProcessor.Core.PaymentGateway;
using System;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices
{
    public  class PaymentGatewayResponse : IPaymentGatewayResponse
    {
        public  PaymentStatus GetResponse()
        {
            var random = new Random();

            var values = Enum.GetValues(typeof(PaymentStatus));

            var result = (PaymentStatus)values.GetValue(random.Next(1, values.Length));

            return result;
        }
    }

    public interface IPaymentGatewayResponse
    {
        PaymentStatus GetResponse();
    }
}
