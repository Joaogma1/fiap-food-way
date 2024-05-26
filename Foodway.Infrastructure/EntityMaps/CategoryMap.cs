using Foodway.Domain.Entities;
using Foodway.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodway.Infrastructure.EntityMaps;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.MapBaseEntity();

        builder.MapVarchar(r => r.Name, 255, false);

        builder.MapIdentifier(c => c.Id);
    }
}