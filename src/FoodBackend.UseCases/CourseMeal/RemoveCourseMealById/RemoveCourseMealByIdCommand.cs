using MediatR;

namespace FoodBackend.UseCases.CourseMeal.RemoveCourseMealById;


/// <summary>
/// Remove course meal by id command.
/// </summary>
/// <param name="CourseMealId">Course meal Id.</param>
public record RemoveCourseMealByIdCommand(Guid CourseMealId) : IRequest;
