using Filed.PaymentProcessor.Core.Data;
using Filed.PaymentProcessor.Core.Payments;
using System.Threading.Tasks;

namespace Filed.PaymentProcessor.Infrastructure.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _dBContext;

        public PaymentRepository(PaymentDbContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task SavePaymentAsync(Payment model)
        {
            _dBContext.Add(model);

            await _dBContext.SaveChangesAsync();
        }
    }
}
