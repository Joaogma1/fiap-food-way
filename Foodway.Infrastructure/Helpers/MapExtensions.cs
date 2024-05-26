using System.Linq.Expressions;
using Foodway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodway.Infrastructure.Helpers;

public static class MapExtensions
{
    public static void MapBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseAuditableEntity
    {

        builder.Property(t => t.CreatedAt)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .IsRequired();

        builder.Property(t => t.LastModifiedAt)
        .HasColumnType("timestamp")
        .ValueGeneratedOnAddOrUpdate()
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .IsRequired();

        builder.MapVarchar(t => t.CreatedBy, 255, false);
        builder.MapVarchar(t => t.LastModifiedBy, 255, false);

        builder.MapBit(t => t.IsDeleted,defaultValue: false);
    }
    public static PropertyBuilder<int> MapIdentifier<T>(this EntityTypeBuilder<T> builder,
     Expression<Func<T, int>> exp,
     string? columnName = null)
     where T : class
    {
        return builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name?.ToLower())
            .HasColumnType("integer")
            .ValueGeneratedOnAdd()
            .IsRequired();
    }

    public static PropertyBuilder<Guid> MapUniqueIdentifier<T>(this EntityTypeBuilder<T> builder,
        Expression<Func<T, Guid>> exp,
        string? columnName = null)
        where T : class
    {
        return builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name?.ToLower())
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd()
            .IsRequired();
    }

    public static PropertyBuilder<Guid?> MapUniqueIdentifier<T>(this EntityTypeBuilder<T> builder,
        Expression<Func<T, Guid?>> exp,
        string? columnName = null)
        where T : class
    {
        return builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name?.ToLower())
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();
    }

    public static PropertyBuilder<string> MapVarchar<T>(this EntityTypeBuilder<T> builder,
        Expression<Func<T, string>> exp,
        int size,
        bool isRequired,
        string? columnName = null)
        where T : class
    {
        var b = builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name)
            .HasColumnType($"varchar({size})");
        return isRequired ? b.IsRequired() : b;
    }

    public static PropertyBuilder<string> MapText<T>(this EntityTypeBuilder<T> builder,
    Expression<Func<T, string>> exp,
    bool isRequired,
    string? columnName = null)
    where T : class
    {
        var b = builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name)
            .HasColumnType($"text");
        return isRequired ? b.IsRequired() : b;
    }

    public static PropertyBuilder<bool> MapBit<T>(this EntityTypeBuilder<T> builder,
        Expression<Func<T, bool>> exp,
        string? columnName = null, bool defaultValue = false)
        where T : class
    {
        return builder.Property(exp)
             .HasColumnName(columnName ?? exp.Name)
             .HasColumnType("boolean")
             .HasDefaultValue(defaultValue)
             .IsRequired();
    }

    public static PropertyBuilder<bool?> MapBit<T>(this EntityTypeBuilder<T> builder,
        Expression<Func<T, bool?>> exp,
        string? columnName = null)
        where T : class
    {
        return builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name)
            .HasColumnType("boolean");
    }

    public static PropertyBuilder<Enum> MapEnumAsVarchar<T>(this EntityTypeBuilder<T> builder,
        Expression<Func<T, Enum>> exp,
        int size,
        bool isRequired,
        string? columnName = null)
        where T : class
    {
        var b = builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name)
            .HasColumnType($"varchar({size})")
            .HasConversion<string>();
        return isRequired ? b.IsRequired() : b;
    }

    public static PropertyBuilder<decimal> MapMoney<T>(this EntityTypeBuilder<T> builder,
    Expression<Func<T, decimal>> exp,
    bool isRequired,
    string? columnName = null)
    where T : class
    {
        var b = builder.Property(exp)
            .HasColumnName(columnName ?? exp.Name)
            .HasColumnType($"decimal(18,2)");
        return isRequired ? b.IsRequired() : b;
    }
}