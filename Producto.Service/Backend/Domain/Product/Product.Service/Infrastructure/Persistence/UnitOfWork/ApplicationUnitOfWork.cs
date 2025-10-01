using Product.Service.Domain.Products.Interfaces;
using Product.Service.Infrastructure.Persistence.Contexts;

namespace Product.Service.Infrastructure.Persistence.UnitOfWork
{    
    public class ApplicationUnitOfWork : UnitOfWork
    {
        public IProductRepository Products { get; }
        public ApplicationContext _context { get; }

        public ApplicationUnitOfWork(
            ApplicationContext context,
            IProductRepository productRepository
        ) : base(context)
        {
            _context = context;
            Products = productRepository;
        }
    }

}
