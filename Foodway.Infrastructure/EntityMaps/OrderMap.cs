using Foodway.Domain.Entities;
using Foodway.Infrastructure.Helpers;
using Foodway.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodway.Infrastructure.EntityMaps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.MapBaseEntity();
            builder.MapUniqueIdentifier(x => x.Id);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ClientId)
                .IsRequired(false);

            builder.MapEnumAsVarchar(x => x.OrderStatus, 20, true)
                .HasDefaultValue(OrderStatus.WaitingApproval);

            builder.MapEnumAsVarchar(x => x.PaymentStatus, 20, true)
                .HasDefaultValue(PaymentStatus.WaitingProvider);

            builder.MapVarchar(x => x.OrderCode, 20, false);

            builder.HasKey(x => x.Id);
        }
    }
}
