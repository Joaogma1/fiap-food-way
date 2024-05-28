namespace Foodway.Domain.Entities;

public class Client : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
}