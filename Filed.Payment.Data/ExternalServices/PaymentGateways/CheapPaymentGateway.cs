using Filed.PaymentProcessor.Core.PaymentGateway;
using Filed.PaymentProcessor.Core.Payments;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        private readonly IPaymentGatewayResponse _response;

        public CheapPaymentGateway(IPaymentGatewayResponse response)
        {
            _response = response;
        }
        public  Task<PaymentStatus> ProcessPayment(PaymentRequest request)
        {
            return Task.FromResult(_response.GetResponse());
        }
    }

    public interface ICheapPaymentGateway : IPaymentGateway { }
}
