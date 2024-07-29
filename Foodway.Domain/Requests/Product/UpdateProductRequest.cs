using System.Text.Json.Serialization;

namespace Foodway.Domain.Requests.Product;

public class UpdateProductRequest : CreateProductRequest
{
    public Guid? Id { get; set; }
}