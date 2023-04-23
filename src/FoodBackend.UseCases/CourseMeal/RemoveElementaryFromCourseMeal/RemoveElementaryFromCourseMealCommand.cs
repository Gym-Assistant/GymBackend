using MediatR;

namespace FoodBackend.UseCases.CourseMeal.RemoveElementaryFromCourseMeal;

/// <summary>
/// Remove food elementary from course meal command.
/// </summary>
/// <param name="FoodElementaryId">Food elementary id.</param>
/// <param name="CourseMealId">Course meal id.</param>
public record RemoveElementaryFromCourseMealCommand(Guid FoodElementaryId, Guid CourseMealId) : IRequest;
