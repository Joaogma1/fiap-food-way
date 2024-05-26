using FluentValidation;
using Foodway.Application.Contracts.Services;
using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Category;
using Foodway.Domain.Requests.Product;
using Foodway.Domain.ViewModels.Product;
using Foodway.Infrastructure.Repositories;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<CreateProductRequest> _createProductValidator;
        private readonly IValidator<UpdateProductRequest> _updateProductValidator;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IDomainNotification notifications, IProductRepository productRepository, IValidator<CreateProductRequest> createProductValidator, IValidator<UpdateProductRequest> updateProductValidator, ICategoryRepository categoryRepository) : base(notifications)
        {
            _productRepository = productRepository;
            _createProductValidator = createProductValidator;
            _updateProductValidator = updateProductValidator;
            _categoryRepository = categoryRepository;
        }

        public async Task<string> CreateAsync(CreateProductRequest req)
        {
            var reqValidation = await _createProductValidator.ValidateAsync(req);

            if (!reqValidation.IsValid)
            {
                HandleValidationErrors(reqValidation);
                return "";
            }
            if (!(await _categoryRepository.AnyAsync(x => x.Id == req.CategoryId)))
            {
                this.Notifications.Handle("Category", $"{req.CategoryId} does not exists");
                return "";
            }
            var createdProduct = await _productRepository.AddAsync(new Product
            { 
                CategoryId = req.CategoryId,
                Name = req.Name,
                Description = req.Description,
                Price = req.Price,
                CreatedBy = "BackOffice",
                LastModifiedBy = "BackOffice",

            });
            await _productRepository.SaveChanges();
            return createdProduct.Id.ToString();
        }

        public Task<PagedList<ProductViewModel>> getPagedAsync(ProductFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAsync(UpdateProductRequest req)
        {
            var reqValidation = await _updateProductValidator.ValidateAsync(req);

            if (!reqValidation.IsValid)
            {
                HandleValidationErrors(reqValidation);
                return "";
            }
            if (!(await _categoryRepository.AnyAsync(x => x.Id == req.CategoryId)))
            {
                this.Notifications.Handle("Category", $"{req.CategoryId} does not exists");
                return "";
            }

            var product = await _productRepository.FindAsync(x => x.Id == req.Id);
            if (product == null)
            {
                var createdProduct = await _productRepository.AddAsync(new Product
                {
                    CategoryId = req.CategoryId,
                    Name = req.Name,
                    Description = req.Description,
                    Price = req.Price,
                    CreatedBy = "BackOffice",
                    LastModifiedBy = "BackOffice",

                });
                await _productRepository.SaveChanges();
                return createdProduct.Id.ToString();
            }
            UpdateProduct(ref product, req);
            await _productRepository.SaveChanges();
            return product.Id.ToString();
        }

        private void UpdateProduct(ref Product product, UpdateProductRequest req)
        {
            product.Name = req.Name;
            product.Description = req.Description;
            product.Price = req.Price;
            product.CategoryId = req.CategoryId;
        }
    }

   
}
