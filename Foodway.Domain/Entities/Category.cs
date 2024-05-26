using Microsoft.AspNetCore.Identity;

namespace Foodway.Domain.Entities;

/// <summary>
///     Represents a Category in the system.
/// </summary>
public class Category : BaseAuditableEntity
{
    public int Id { get; set; }
    
    public string Name { get; set; }

}