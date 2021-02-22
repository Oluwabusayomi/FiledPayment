using AutoMapper;
using Filed.PaymentProcessor.DomainServices.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Filed.PaymentProcessor.DomainServices.Bootstrap
{
    public static class MapperConfig
    {
        public static void AddDomainMapperProfileConfiguration(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainMapper>();
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

    }
}
