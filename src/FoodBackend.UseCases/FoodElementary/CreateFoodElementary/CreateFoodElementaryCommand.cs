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
    
    /// <summary>
    /// Food elementary protein characteristic value.
    /// </summary>
    public double ProteinValue { get; init; }
    
    /// <summary>
    /// Food elementary fat characteristic value.
    /// </summary>
    public double FatValue { get; init; }
    
    /// <summary>
    /// Food elementary carbohydrate characteristic value.
    /// </summary>
    public double CarbohydrateValue { get; init; }
    
    /// <summary>
    /// Food elementary empty calories characteristic value.
    /// </summary>
    public double EmptyCaloriesValue { get; init; }
}
