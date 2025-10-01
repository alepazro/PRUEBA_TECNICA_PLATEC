using FluentValidation;
using FluentValidation.Results;
using Product.Service.Application.Dtos;
using Product.Service.Application.Interfaces;

namespace Product.Service.Application.Validators
{   
    public class ValidationService : IValidationService
    {
        private readonly IValidator<ProductForCreationDto> _productCreationValidator;
        private readonly IValidator<ProductForUpdateDto> _productUpdateValidator;

        public ValidationService(
            IValidator<ProductForCreationDto> productCreationValidator,
            IValidator<ProductForUpdateDto> productUpdateValidator
        )
        {
            _productCreationValidator = productCreationValidator;
            _productUpdateValidator = productUpdateValidator;
        }

        public ValidationResult ValidateProductCreation(ProductForCreationDto dto)
        {
            return _productCreationValidator.Validate(dto);
        }

        public ValidationResult ValidateProductUpdate(ProductForUpdateDto dto)
        {
            return _productUpdateValidator.Validate(dto);
        }

        
    }

}
