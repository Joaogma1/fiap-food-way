using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Infrastructure.Contexts;

namespace Foodway.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}