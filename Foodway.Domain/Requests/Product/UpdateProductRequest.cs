using System.Text.Json.Serialization;

namespace Foodway.Domain.Requests.Product;

public class UpdateProductRequest : CreateProductRequest
{
    [JsonIgnore] public Guid? Id { get; set; }
}