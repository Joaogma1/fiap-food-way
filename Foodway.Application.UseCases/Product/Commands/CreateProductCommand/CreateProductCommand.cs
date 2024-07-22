using Foodway.Shared.Results;
using MediatR;

namespace Foodway.Application.UseCases.Product.Commands.CreateProductCommand;

public class CreateProductCommand : IRequest<string>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int Stock { get; set; }
}