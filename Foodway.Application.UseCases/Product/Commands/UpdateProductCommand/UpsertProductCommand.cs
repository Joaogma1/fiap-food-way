using System.Text.Json.Serialization;

namespace Foodway.Application.UseCases.Product.Commands.UpdateProductCommand;

using CreateProductCommand;

public class UpsertProductCommand : CreateProductCommand
{
    [JsonIgnore] public Guid? Id { get; set; }
}