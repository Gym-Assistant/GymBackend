using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.CreateFoodElementary;

/// <summary>
/// Create food elementary command.
/// </summary>
public record CreateFoodElementaryCommand : IRequest<Guid>
{
    /// <summary>
    /// Food elementary name.
    /// </summary>
    [Required]
    public string Name { get; init; }
}
