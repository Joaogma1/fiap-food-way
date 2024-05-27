using Foodway.Domain.Entities;
using Foodway.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodway.Infrastructure.EntityMaps;

public class ClientsMap : IEntityTypeConfiguration<Clients>
{
    public void Configure(EntityTypeBuilder<Clients> builder)
    {
        builder.MapBaseEntity();

        builder.MapVarchar(r => r.Name, 255, false);
        builder.MapVarchar(r => r.Email, 255, false);
        builder.MapVarchar(r => r.CPF, 11, false);
        builder.MapUniqueIdentifier(x => x.Id);
    }
}