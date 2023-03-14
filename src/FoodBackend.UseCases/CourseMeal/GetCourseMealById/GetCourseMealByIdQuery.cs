using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealById;

/// <summary>
/// Get food characteristic type by id query.
/// </summary>
public record GetCourseMealByIdQuery(Guid CourseMealId) : IRequest<LightCourseMealDto>;
