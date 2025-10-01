using Product.Service.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Product.Service.Infrastructure.Http.Results.Products
{
    public class UpdateProductResult
    {
        public ProductDto ProductUpserted { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}
