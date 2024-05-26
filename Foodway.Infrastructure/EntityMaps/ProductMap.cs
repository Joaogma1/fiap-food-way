using Foodway.Domain.Entities;
using Foodway.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Infrastructure.EntityMaps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.MapBaseEntity();
            builder.MapUniqueIdentifier(x => x.Id);
            builder.MapVarchar(x => x.Name, 100, true);
            builder.MapText(x => x.Description, true);
            builder.MapMoney(x => x.Price, true);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}
