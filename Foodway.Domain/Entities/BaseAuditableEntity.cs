namespace Foodway.Domain.Entities;

/// <summary>
///     The base class for all entities in the application.
/// </summary>
public class BaseAuditableEntity
{
    protected BaseAuditableEntity()
    {
        IsDeleted = false;
    }

    /// <summary>
    ///     Gets or sets the creation date and time of the object.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Gets or sets the last modified date and time of the object.
    /// </summary>
    public DateTime? LastModifiedAt { get; set; }

    /// <summary>
    ///     Gets or sets the identification of the entity that created the object.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets the identification of the entity that last modified the object.
    /// </summary>
    public string LastModifiedBy { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is deleted.
    /// </summary>
    /// <value>True if this instance is deleted; otherwise, false.</value>
    public bool IsDeleted { get; set; }
}