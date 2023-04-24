using MediatR;

namespace FoodBackend.UseCases.CourseMeal.RemoveRecipeFromCourseMeal;

/// <summary>
/// Remove recipe from course meal command.
/// </summary>
/// <param name="FoodRecipeId">Food recipe id.</param>
/// <param name="CourseMealId">Course meal id.</param>
public record RemoveRecipeFromCourseMealCommand(Guid FoodRecipeId, Guid CourseMealId) : IRequest;
