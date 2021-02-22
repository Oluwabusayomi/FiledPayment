using Filed.PaymentProcessor.Core.PaymentGateway;
using Filed.PaymentProcessor.Core.Payments;
using Polly;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        private readonly IPaymentGatewayResponse _response;
        public PremiumPaymentGateway(IPaymentGatewayResponse response)
        {
            _response = response;
        }
        public  Task<PaymentStatus> ProcessPayment(PaymentRequest request)
        {
            var response =  Policy.HandleResult<PaymentStatus>(s => s != PaymentStatus.Processed)
                       .Retry(3).Execute( () =>
                       {
                           return _response.GetResponse();
                       });

            return Task.FromResult(response);
        }
    }

    public interface IPremiumPaymentGateway : IPaymentGateway { }
}
