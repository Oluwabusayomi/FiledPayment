using Filed.PaymentProcessor.Core.Payments;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Core.Data
{
    public interface IPaymentRepository
    {
        Task SavePaymentAsync(Payment model);
    }
}
