using Filed.PaymentProcessor.Core.Payments;
using Microsoft.EntityFrameworkCore;

namespace Filed.PaymentProcessor.Infrastructure.Data.EntityConfig
{
    static class PaymentConfig
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<Payment>();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreditCardNumber)
                 .IsRequired().HasMaxLength(20);

            builder.Property(p => p.CardHolder)
               .IsRequired().HasMaxLength(100);

            builder.Property(p => p.ExpirationDate)
               .IsRequired();

            builder.Property(p => p.SecurityCode)
              .HasMaxLength(3);

            builder.Property(p => p.Amount)
               .HasPrecision(18,2)
               .IsRequired();

           builder.HasOne(p => p.PaymentState)
          .WithOne(p => p.Payment)
          .HasForeignKey<PaymentState>(p => p.PaymentId);

        }
    }
}
