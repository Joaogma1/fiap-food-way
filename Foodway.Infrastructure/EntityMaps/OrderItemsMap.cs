using Foodway.Domain.Entities;
using Foodway.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodway.Infrastructure.EntityMaps;

public class OrderItemsMap : IEntityTypeConfiguration<OrderItems>
{
    public void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        builder.HasKey(x => new
        {
            x.OrderId,
            x.ProductId
        });
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductOrders)
            .HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId);
        builder.MapNumber(x => x.Quantity);
    }
}