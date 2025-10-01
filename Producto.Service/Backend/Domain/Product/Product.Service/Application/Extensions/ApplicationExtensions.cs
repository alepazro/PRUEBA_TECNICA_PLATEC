using FluentValidation.AspNetCore;
using Product.Service.Application.Interfaces;
using Product.Service.Application.Mappers;
using Product.Service.Application.Services;
using Product.Service.Application.Validators;


namespace Product.Service.Application.Extensions
{   
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductMapper));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductForCreationDtoValidator>());
            services.AddTransient<IValidationService, ValidationService>();
            services.AddScoped<IApplicationService, ApplicationService>();

        }
    }
}
