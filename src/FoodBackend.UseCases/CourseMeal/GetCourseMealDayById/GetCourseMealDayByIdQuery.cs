using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealDayById;

/// <summary>
/// Get course meal day by id query.
/// </summary>
/// <param name="CourseMealDayId">Course meal day id.</param>
public record GetCourseMealDayByIdQuery(Guid CourseMealDayId) : IRequest<LightCourseMealDayDto>;
