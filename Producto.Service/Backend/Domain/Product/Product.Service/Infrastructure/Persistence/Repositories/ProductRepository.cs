using Microsoft.EntityFrameworkCore;
using Product.Service.Application.Dtos;
using Product.Service.Domain.Products.Entities;
using Product.Service.Domain.Products.Interfaces;
using Product.Service.Infrastructure.Persistence.Contexts;

namespace Product.Service.Infrastructure.Persistence.Repositories
{
  
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(
            ApplicationContext context
        )
        {
            _context = context;
        }

        public async Task<ProductEntity> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(a => a.ProductId == productId);
        }

        public async Task<List<ProductEntity>> GetProductsAsync(ProductResourceParameters productResourceParameters)
        {
            var queryProducts = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(productResourceParameters.Name))
            {
                var nameForWhereClause = productResourceParameters.Name.Trim().ToLower();
                queryProducts = queryProducts.Where(a => a.Name.ToLower().Contains(nameForWhereClause));
            }

            return queryProducts.ToList();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByIdsAsync(List<Guid> ProductIds)
        {
            return await _context.Products.Where(a => ProductIds.Contains(a.ProductId))
                           .OrderBy(a => a.Name)
                           .ToListAsync();
        }
        public async Task<bool> ProductExists(Guid productId)
        {
            return await _context.Products.AnyAsync(a => a.ProductId == productId);
        }

        public async Task AddProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
        }
        public async Task UpdateProductsAsync(ProductEntity productEntity)
        {
            var productUpdate = await GetProductByIdAsync(productEntity.ProductId);
            if (productUpdate != null)
            {
                productUpdate.Name = productEntity.Name;
                productUpdate.Price = productEntity.Price;
                productUpdate.Quantity = productEntity.Quantity;
                productUpdate.UpdatedAt = DateTime.Now;
                productUpdate.UpdatedBy = "System";
            }
        }    
        public async Task DeleteProductAsync(ProductEntity product)
        {
            await Task.FromResult(_context.Products.Remove(product));
        }

       
       



    }

}
