using FluentValidation;
using Foodway.Domain.Requests.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Application.Validations
{
    public class UpdateProductRequestValidator: BaseValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name is required");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Product price is not empty")
                .GreaterThan(0)
                .WithMessage("Product price must be greater than 0");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Category is required")
                .GreaterThan(0)
                .WithMessage("Category id must be greater than 0");

        }
    }
}
