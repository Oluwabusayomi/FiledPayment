using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGatewayFactory;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.PaymentGateways;
using Microsoft.Extensions.DependencyInjection;

namespace Filed.PaymentProcessor.Infrastructure.ExternalServices.Bootstrap
{
    public static class ExternalServiceIocModule
    {
        public static void ConfigureExternalServiceModule(this IServiceCollection services)
        {
            services.AddScoped<IPaymentGatewayFactory, PaymentGatewayFactory.PaymentGatewayFactory>();

            services.AddScoped<IPaymentGatewayResponse, PaymentGatewayResponse>();

            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();

            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();

            services.AddScoped<IPremiumPaymentGateway, PremiumPaymentGateway>();
        }
    }
}
