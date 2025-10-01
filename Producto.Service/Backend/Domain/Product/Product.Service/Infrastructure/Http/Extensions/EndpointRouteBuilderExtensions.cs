using Product.Service.Infrastructure.Http.EndpointHandlers;

namespace Product.Service.Infrastructure.Http.Extensions
{
   
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterProductsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var productsEndpoints = endpointRouteBuilder
                .MapGroup("api/products")
                .WithTags("Products");

            productsEndpoints.MapGet("", ProductsHandlers.GetProductsAsync)
                .WithName("GetProducts")
                .WithOpenApi();

            productsEndpoints.MapGet("/{ProductId:guid}", ProductsHandlers.GetProductByIdAsync)
                .WithName("GetProduct")
                .WithOpenApi();

            productsEndpoints.MapPost("", ProductsHandlers.CreateProductAsync)
               .ProducesValidationProblem(422)
               .WithName("CreateProduct")
               .WithOpenApi();

            productsEndpoints.MapDelete("/{productId:guid}", ProductsHandlers.DeleteProductAsync)
                .WithName("DeleteProduct")
                .WithOpenApi();

            productsEndpoints.MapPut("/{productId:guid}", ProductsHandlers.UpdateProductAsync)
                .ProducesValidationProblem(422)
                .WithName("UpdateProduct")
                .WithOpenApi();
        }
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterProductsEndpoints();
        }
    }

}
