using Filed.PaymentProcessor.DomainServices.Bootstrap;
using Filed.PaymentProcessor.Infrastructure.Data.Bootstrap;
using Filed.PaymentProcessor.Infrastructure.ExternalServices.Bootstrap;
using Microsoft.Extensions.DependencyInjection;


namespace Filed.PaymentProcessor.UIApi.Bootsrap
{
    public static class IocConfig
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.ConfigureDomainModule();

            services.ConfigureDataModule();

            services.ConfigureExternalServiceModule();
        }
    }
}
