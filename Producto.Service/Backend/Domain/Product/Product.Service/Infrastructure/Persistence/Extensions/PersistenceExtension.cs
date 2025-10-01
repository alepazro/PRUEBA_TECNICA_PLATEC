using Microsoft.EntityFrameworkCore;
using Product.Service.Domain.Products.Interfaces;
using Product.Service.Infrastructure.Persistence.Contexts;
using Product.Service.Infrastructure.Persistence.Repositories;
using Product.Service.Infrastructure.Persistence.UnitOfWork;

namespace Product.Service.Infrastructure.Persistence.Extensions
{   
    public class PersistenceOptions
    {
        public string ConnectionString { get; set; }
    }

    public static class PersistenceExtension
    {       
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> configure)
        {
            var options = new PersistenceOptions();
            configure(options);

            services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(options.ConnectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ApplicationUnitOfWork>();
        }
    }

}
