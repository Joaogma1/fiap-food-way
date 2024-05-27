using FluentValidation;
using Foodway.Domain.Requests.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Application.Validations
{
    public class CreateClientRequestValidatior : BaseValidator<CreateClientRequest>
    {
        public CreateClientRequestValidatior()
        {
            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("CPF is Required");

            RuleFor(x => x.CPF)
                .MinimumLength(10)
                .MaximumLength(11)
                .WithMessage("CPF is invalid it must contains 11 chars - no format");

             RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is Required");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is Required");
        }
    }
}
