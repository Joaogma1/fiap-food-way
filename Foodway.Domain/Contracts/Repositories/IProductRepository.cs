using Foodway.Domain.Entities;
using Foodway.Domain.QueryFilters;
using Foodway.Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Domain.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Expression<Func<Product, bool>> Where(ProductFilter filter);
    }
}
