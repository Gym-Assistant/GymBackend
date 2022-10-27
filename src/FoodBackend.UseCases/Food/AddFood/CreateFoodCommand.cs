using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FoodBackend.UseCases.Food.AddFood;

/// <summary>
/// Create food command.
/// </summary>
/// <param name="Name">Name of food.</param>
/// <param name="Callories">Value of food callories.</param>
/// <param name="Protein">Value of food protein.</param>
/// <param name="Carbohydrates">Value of food carbohydrates.</param>
/// <param name="Fat">Value of food fat.</param>
public record CreateFoodCommand() : IRequest<Guid>
{
    /// <summary>
    /// Food name.
    /// </summary>
    [Required]
    public string Name { get; init; }

    /// <summary>
    /// Food callories value.
    /// </summary>
    public int? Callories { get; init; }

    /// <summary>
    /// Food protein value.
    /// </summary>
    public double? Protein { get; init; }

    /// <summary>
    /// Food carbohydrates value.
    /// </summary>
    public double? Carbohydrates { get; init; }

    /// <summary>
    /// Food carbohydrates value.
    /// </summary>
    public double? Fat { get; init; }
}
