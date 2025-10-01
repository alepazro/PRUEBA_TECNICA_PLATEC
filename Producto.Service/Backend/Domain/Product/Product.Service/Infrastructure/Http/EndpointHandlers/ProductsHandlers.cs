using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Product.Service.Application.Dtos;
using Product.Service.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Product.Service.Infrastructure.Http.EndpointHandlers
{   
    public static class ProductsHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<ProductDto>>>> GetProductsAsync(
            [FromServices] IApplicationService _ApplicationService,
            [AsParameters] ProductResourceParameters productResourceParameters
        )
        {
            var result = await _ApplicationService.GetProductsAsync(productResourceParameters);
            return TypedResults.Ok(result.Products);
        }
        public static async Task<Results<BadRequest, NotFound, Ok<ProductDto>>> GetProductByIdAsync(
           [FromServices] IApplicationService _ApplicationService,
           Guid ProductId
        )
        {
            var result = await _ApplicationService.GetProductByIdAsync(ProductId);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.Product);
        }
        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<ProductDto>, Ok<ProductDto>>> CreateProductAsync(
            [FromServices] IApplicationService _ApplicationService,
            [FromBody] ProductForCreationDto product
        )
        {
            if (product == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _ApplicationService.CreateProductAsync(product);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            return TypedResults.CreatedAtRoute(result.Product, $"GetProduct", new { result.Product.ProductId });
        }

        public static async Task<Results<NotFound, NoContent>> DeleteProductAsync(
           [FromServices] IApplicationService _ApplicationService,
           Guid productId
        )
        {
            var result = await _ApplicationService.DeleteProductAsync(productId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }
        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<ProductDto>, UnprocessableEntity<List<ValidationResult>>, Ok<ProductDto>>> UpdateProductAsync(
           [FromServices] IApplicationService _ApplicationService,
           [FromBody] ProductForUpdateDto product,
           Guid productId
        )
        {
            if (product == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _ApplicationService.UpdateProductAsync(productId, product);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            if (result.Success && result.ProductUpserted != null)
            {
                return TypedResults.CreatedAtRoute(result.ProductUpserted, $"GetProduct", new { productId = result.ProductUpserted.ProductId });
            }

            return TypedResults.NoContent();
        }
    }

}
