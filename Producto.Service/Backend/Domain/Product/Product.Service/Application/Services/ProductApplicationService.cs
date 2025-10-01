using Product.Service.Application.Dtos;
using Product.Service.Application.Interfaces;
using Product.Service.Domain.Products.Entities;
using Product.Service.Infrastructure.Http.Results.Products;
using System.ComponentModel.DataAnnotations;

namespace Product.Service.Application.Services
{
   
    public partial class ApplicationService : IApplicationService
    {
        public async Task<GetProductsResult> GetProductsAsync(ProductResourceParameters productResourceParameters)
        {
            GetProductsResult result = new();

            var productsFromRepo = await _unitOfWork.Products.GetProductsAsync(productResourceParameters);
            var products = _mapper.Map<List<ProductDto>>(productsFromRepo);

            result.Products = products;
            return result;
        }

        public async Task<CreateProductResult> CreateProductAsync(ProductForCreationDto product)
        {
            CreateProductResult result = new();
            var validationResult = _validationService.ValidateProductCreation(product);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var productEntity = _mapper.Map<ProductEntity>(product);
            productEntity.CreatedBy = "SYSTEM";
            productEntity.CreatedAt = DateTime.Now;
            productEntity.Status=true;

            await _unitOfWork.Products.AddProductAsync(productEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an author failed on save.");
            }

            result.Product = _mapper.Map<ProductDto>(productEntity);
            result.Success = true;
            return result;
        }

        public async Task<bool?> DeleteProductAsync(Guid productId)
        {
            var productFromRepo = await _unitOfWork.Products.GetProductByIdAsync(productId);
            if (productFromRepo == null)
            {
                return null;
            }

            await _unitOfWork.Products.DeleteProductAsync(productFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting product {productId} failed on save.");
            }

            return true;
        }
        

        public async Task<GetProductByIdResult> GetProductByIdAsync(Guid productId)
        {
            GetProductByIdResult result = new();
            var productFromRepo = await _unitOfWork.Products.GetProductByIdAsync(productId);

            if (productFromRepo == null)
            {
                return null;
            }

            var author = _mapper.Map<ProductDto>(productFromRepo);
            result.Product = author;
            return result;
        }

        

        public Task<bool> ProductExistsAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateProductResult> UpdateProductAsync(Guid productId, ProductForUpdateDto product)
        {
            UpdateProductResult result = new();
            var validationResult = _validationService.ValidateProductUpdate(product);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var productFromRepo = await _unitOfWork.Products.GetProductByIdAsync(productId);
            _mapper.Map(product, productFromRepo);
            await _unitOfWork.Products.UpdateProductsAsync(productFromRepo);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating product {productId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        /*
        public async Task<bool> AuthorExistsAsync(Guid authorId)
        {
            return await _unitOfWork.Authors.AuthorExists(authorId);
        }

        */
    }

}

