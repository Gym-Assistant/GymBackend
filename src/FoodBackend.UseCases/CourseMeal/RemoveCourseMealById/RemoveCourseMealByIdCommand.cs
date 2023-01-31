using MediatR;

namespace FoodBackend.UseCases.CourseMeal.RemoveCourseMealById;

/// <summary>
/// Remove course meal by id.
/// </summary>
public record RemoveCourseMealByIdCommand(Guid CourseMealId) : IRequest;
