using MediatR;

namespace FoodBackend.UseCases.CourseMeal.RemoveElementaryFromCourseMeal;

/// <summary>
/// Remove food elementary from course meal command.
/// </summary>
public record RemoveElementaryFromCourseMealCommand(Guid FoodElementaryId, Guid CourseMealId) : IRequest;
