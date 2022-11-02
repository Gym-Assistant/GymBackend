using MediatR;
using System.Text.Json.Serialization;

namespace FoodBackend.UseCases.Food.UpdateFood;

public record UpdateFoodCommand : IRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; set; }

    /// <summary>
    /// Food name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Food callories value.
    /// </summary>
    public int? Callories { get; set; }

    /// <summary>
    /// Food protein value.
    /// </summary>
    public double? Protein { get; set; }

    /// <summary>
    /// Food carbohydrates value.
    /// </summary>
    public double? Carbohydrates { get; set; }

    /// <summary>
    /// Food fat value.
    /// </summary>
    public double? Fat { get; set; }
}
