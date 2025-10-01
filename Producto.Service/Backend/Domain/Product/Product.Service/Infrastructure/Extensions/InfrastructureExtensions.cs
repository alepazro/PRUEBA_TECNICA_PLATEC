using Microsoft.AspNetCore.Builder;
using Product.Service.Infrastructure.Http.Extensions;
using Product.Service.Infrastructure.Persistence.Extensions;

namespace Product.Service.Infrastructure.Extensions
{   
    public class InfrastructureOptions
    {
        public string ConnectionString { get; set; }
    }
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> configure)
        {
            var options = new InfrastructureOptions();
            configure(options);

            services.AddHttp();
            services.AddPersistence(opt => opt.ConnectionString = options.ConnectionString);
        }
    }
}
