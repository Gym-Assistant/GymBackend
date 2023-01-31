using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.MealType.GetMealTypeById;

/// <summary>
/// Get meal type by id query.
/// </summary>
public record GetMealTypeByIdQuery(Guid MealTypeId) : IRequest<LightMealTypeDto>;
