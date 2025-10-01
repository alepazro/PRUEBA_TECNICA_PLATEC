using FluentValidation;
using Product.Service.Application.Dtos;

namespace Product.Service.Application.Validators
{
   
    public class ProductForUpdateDtoValidator : AbstractValidator<ProductForUpdateDto>
    {
        public ProductForUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor a cero.");
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("La cantidad debe ser mayor a cero.");

        }
    }
}
