using System.Linq.Expressions;
using Foodway.Domain.Entities;
using Foodway.Domain.QueryFilters;
using Foodway.Shared.Persistence;

namespace Foodway.Domain.Contracts.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Expression<Func<Product, bool>> Where(ProductFilter filter);
}