using FluentValidation;
using Product.Service.Application.Dtos;

namespace Product.Service.Application.Validators
{   
    public class ProductForCreationDtoValidator : AbstractValidator<ProductForCreationDto>
    {
        public ProductForCreationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("La cantidad debe ser mayor a cero.");

        }
    }
}
