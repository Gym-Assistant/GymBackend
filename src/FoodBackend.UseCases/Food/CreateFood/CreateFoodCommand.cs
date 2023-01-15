using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FoodBackend.UseCases.Food.CreateFood;

/// <summary>
/// Create food command.
/// </summary>
public record CreateFoodCommand : IRequest<Guid>
{
    /// <summary>
    /// Food name.
    /// </summary>
    [Required]
    public string Name { get; init; }
}
