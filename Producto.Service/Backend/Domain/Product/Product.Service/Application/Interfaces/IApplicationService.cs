using Product.Service.Application.Dtos;
using Product.Service.Infrastructure.Http.Results.Products;

namespace Product.Service.Application.Interfaces
{
    public interface IApplicationService
    {
        Task<GetProductsResult> GetProductsAsync(ProductResourceParameters productResourceParameters);
        Task<bool> ProductExistsAsync(Guid productId);
        Task<CreateProductResult> CreateProductAsync(ProductForCreationDto product);
        Task<bool?> DeleteProductAsync(Guid productId);
        Task<GetProductByIdResult> GetProductByIdAsync(Guid productId);
        Task<UpdateProductResult> UpdateProductAsync(Guid productId, ProductForUpdateDto product);
    }
}
