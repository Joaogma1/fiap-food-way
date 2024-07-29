using MediatR;

namespace Foodway.Application.UseCases.Product.Commands.DeleteProductCommand;

public class DeleteProductCommand : IRequest<bool>
{
    public DeleteProductCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}