using Filed.PaymentProcessor.Core.Payments;
using Filed.PaymentProcessor.DomainServices.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace Filed.PaymentProcessor.DomainServices.Bootstrap
{
    public static class DomainIocModule
    {
        public static void ConfigureDomainModule(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
