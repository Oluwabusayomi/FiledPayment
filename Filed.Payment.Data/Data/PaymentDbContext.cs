using Filed.PaymentProcessor.Core.Payments;
using Filed.PaymentProcessor.Infrastructure.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Filed.PaymentProcessor.Infrastructure.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PaymentConfig.Configure(modelBuilder);

            PaymentStateConfig.Configure(modelBuilder);
        }
        #endregion

    }
}
