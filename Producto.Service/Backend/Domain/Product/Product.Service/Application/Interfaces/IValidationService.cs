using FluentValidation.Results;
using Product.Service.Application.Dtos;

namespace Product.Service.Application.Interfaces
{   
    public interface IValidationService
    {
        ValidationResult ValidateProductCreation(ProductForCreationDto dto);
        ValidationResult ValidateProductUpdate(ProductForUpdateDto dto);
    }
}
