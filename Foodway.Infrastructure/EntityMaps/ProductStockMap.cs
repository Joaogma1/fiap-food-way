using Foodway.Domain.Entities;
using Foodway.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodway.Infrastructure.EntityMaps;

public class ProductStockMap : IEntityTypeConfiguration<ProductStock>
{
    public void Configure(EntityTypeBuilder<ProductStock> builder)
    {
        builder.MapNumber(x => x.QuantityInStock, true);

        builder.MapUniqueIdentifier(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithOne(x => x.Stock)
            .HasForeignKey<ProductStock>(x => x.ProductId)
            .IsRequired();

        builder.HasKey(x => new { x.ProductId, x.Id });
    }
}