using Foodway.Infrastructure.EntityMaps;
using Foodway.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Foodway.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Context = this;
    }

    public DbContext Context { get; protected set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
        modelBuilder.ToSnakeCase();
    }
}