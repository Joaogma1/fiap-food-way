using Foodway.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Foodway.Infrastructure.Helpers;

public static class ModelBuilderExtension
{
    public static void ToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Replace table names
            entity.SetTableName((entity.GetTableName() ?? string.Empty).ToSnakeCase());

            // Replace column names            
            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            foreach (var key in entity.GetKeys()) key.SetName((key.GetName() ?? string.Empty).ToSnakeCase());

            foreach (var key in entity.GetForeignKeys())
                key.SetConstraintName((key.GetConstraintName() ?? string.Empty).ToSnakeCase());
        }
    }
}