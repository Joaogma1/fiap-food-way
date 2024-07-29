namespace Foodway.Domain.Requests.Category;

public class UpdateCategoryRequest : CreateCategoryRequest
{
    public Guid? Id { get; set; }
}