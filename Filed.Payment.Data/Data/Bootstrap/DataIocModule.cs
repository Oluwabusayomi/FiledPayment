using Filed.PaymentProcessor.Core.Data;
using Filed.PaymentProcessor.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Filed.PaymentProcessor.Infrastructure.Data.Bootstrap
{
    public static class DataIocModule
    {
        public static void ConfigureDataModule(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
