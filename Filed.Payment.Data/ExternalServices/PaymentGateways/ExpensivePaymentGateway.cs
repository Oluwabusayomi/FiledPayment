using Filed.PaymentProcessor.Core.PaymentGateway;
using Filed.PaymentProcessor.Core.Payments;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly IPaymentGatewayResponse _response;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        public ExpensivePaymentGateway(IPaymentGatewayResponse response, ICheapPaymentGateway cheapPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _response = response;
        }
        public async Task<PaymentStatus> ProcessPayment(PaymentRequest request)
        {
            PaymentStatus statusCode = default;

            statusCode = _response.GetResponse();

            if (statusCode == PaymentStatus.Unavailable)
            {
                statusCode = await _cheapPaymentGateway.ProcessPayment(request);
            }

            return await Task.FromResult(statusCode);
        }

    }
    public interface IExpensivePaymentGateway : IPaymentGateway { }
}
