namespace Foodway.Domain.Requests.Clients;

public class CreateClientRequest
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
}