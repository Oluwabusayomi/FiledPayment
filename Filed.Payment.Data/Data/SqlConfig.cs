using Filed.PaymentProcessor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Filed.PaymentProcessor.Infrastructure.Data
{
    public static class SqlConfig
    {
        public static void AddSQLConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(option =>
                   option.UseSqlServer(configuration.GetConnectionString("FiledPaymentDbConn"), m =>
                   m.MigrationsAssembly(typeof(PaymentDbContext).Assembly.FullName)));
        }
    }
}
