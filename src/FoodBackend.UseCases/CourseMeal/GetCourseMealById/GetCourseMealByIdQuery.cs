using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealById;

/// <summary>
/// Get course meal by id detail query.
/// </summary>
/// <param name="CourseMealId">Course meal id.</param>
public record GetCourseMealByIdQuery(Guid CourseMealId) : IRequest<DetailCourseMealDto>;
