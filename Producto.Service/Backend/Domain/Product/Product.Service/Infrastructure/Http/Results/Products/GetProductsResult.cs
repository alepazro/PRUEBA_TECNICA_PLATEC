using Product.Service.Application.Dtos;

namespace Product.Service.Infrastructure.Http.Results.Products
{
    public class GetProductsResult
    {
        public List<ProductDto> Products { get; set; }

    }
}
