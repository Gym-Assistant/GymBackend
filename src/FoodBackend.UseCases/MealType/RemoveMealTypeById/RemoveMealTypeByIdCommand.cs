using MediatR;

namespace FoodBackend.UseCases.MealType.RemoveMealTypeById;

/// <summary>
/// Remove meal type by id.
/// </summary>
public record RemoveMealTypeByIdCommand(Guid MealTypeId) : IRequest<Unit>;
