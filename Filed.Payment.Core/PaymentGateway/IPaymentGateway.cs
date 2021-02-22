using Filed.PaymentProcessor.Core.Payments;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Core.PaymentGateway
{
    public interface IPaymentGateway
    {
        Task<PaymentStatus> ProcessPayment(PaymentRequest request);
    }
}
