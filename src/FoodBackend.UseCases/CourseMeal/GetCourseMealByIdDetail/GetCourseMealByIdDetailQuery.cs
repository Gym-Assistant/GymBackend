using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealByIdDetail;

/// <summary>
/// Get course meal by id detail query.
/// </summary>
/// <param name="CourseMealId">Course meal id.</param>
public record GetCourseMealByIdDetailQuery(Guid CourseMealId) : IRequest<DetailCourseMealDto>;
