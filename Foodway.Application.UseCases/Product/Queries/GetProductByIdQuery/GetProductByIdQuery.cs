using Foodway.Domain.ViewModels.Product;
using MediatR;

namespace Foodway.Application.UseCases.Product.Queries.GetProductByIdQuery;

public class GetProductByIdQuery : IRequest<ProductViewModel?>
{
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}