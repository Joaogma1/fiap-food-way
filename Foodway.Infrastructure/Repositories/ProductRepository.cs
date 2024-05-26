using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.QueryFilters;
using Foodway.Infrastructure.Contexts;
using Foodway.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public Expression<Func<Product, bool>> Where(ProductFilter filter)
        {
            var predicate = PredicateBuilder.True<Product>();

            predicate = string.IsNullOrEmpty(filter.Name) ? predicate : predicate.And(x => EF.Functions.Like(x.Name.ToLower(),
                $"%{filter.Name.ToLower()}%"));

            predicate = !filter.CategoryId.HasValue ? predicate : predicate.And(x => x.CategoryId == filter.CategoryId.Value);

            return predicate;
        }
    }
}
