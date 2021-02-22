using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Core.Payments
{
    public interface IPaymentService
    {
        Task ProcessPayment(PaymentRequest request);
    }
}
