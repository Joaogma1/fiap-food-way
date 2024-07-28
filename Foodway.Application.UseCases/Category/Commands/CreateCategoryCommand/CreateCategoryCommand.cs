using Foodway.Shared.Results;
using MediatR;

namespace Foodway.Application.UseCases.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommand : IRequest<string>
{
    public string Name { get; set; }
}