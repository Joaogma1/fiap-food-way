using Foodway.Domain.ViewModels.Category;
using MediatR;

namespace Foodway.Application.UseCases.Category.Queries.ListCategoriesQuery;

public class ListCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>
{
}