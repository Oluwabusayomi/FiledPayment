using Filed.PaymentProcessor.Core.Payments;
using Microsoft.EntityFrameworkCore;

namespace Filed.PaymentProcessor.Infrastructure.Data.EntityConfig
{
    internal static class PaymentStateConfig
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<PaymentState>();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.State)
                 .IsRequired();
        }
    }
}
