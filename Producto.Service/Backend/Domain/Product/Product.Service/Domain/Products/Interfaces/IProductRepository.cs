
using Product.Service.Application.Dtos;
using Product.Service.Domain.Products.Entities;

namespace Product.Service.Domain.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetProductByIdAsync(Guid productId);
        Task<List<ProductEntity>> GetProductsAsync(ProductResourceParameters productResourceParameters);
        Task<IEnumerable<ProductEntity>> GetProductsByIdsAsync(List<Guid> ProductIds);
        Task<bool> ProductExists(Guid productId);
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductsAsync(ProductEntity productEntity);
        Task DeleteProductAsync(ProductEntity product);
        
    }
}
