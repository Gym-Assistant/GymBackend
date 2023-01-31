using MediatR;

namespace FoodBackend.UseCases.MealType.CreateMealType;

/// <summary>
/// Create meal type id.
/// </summary>
public record CreateMealTypeCommand : IRequest<Guid>
{
    /// <summary>
    /// Name of meal type.
    /// </summary>
    public string Name { get; init; }
}
