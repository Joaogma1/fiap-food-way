using Foodway.Domain.Entities;
using Foodway.Domain.ViewModels.Role;
using System.Runtime.CompilerServices;

namespace Foodway.Domain.Projections;

public static class CategoryProjection
{
    public static IQueryable<CategoryViewModel> ToViewModel (this IQueryable<Category> query) => query.Select(x => new CategoryViewModel { Id = x.Id, Name = x.Name, });

    public static CategoryViewModel ToViewModel(this Category category) =>  new CategoryViewModel { Id = category.Id, Name = category.Name };

}