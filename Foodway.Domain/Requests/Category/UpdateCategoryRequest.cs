using System.Text.Json.Serialization;

namespace Foodway.Domain.Requests.Category;

public class UpdateCategoryRequest : CreateCategoryRequest
{
    [JsonIgnore] 
    public Guid? ID { get; set; }
}