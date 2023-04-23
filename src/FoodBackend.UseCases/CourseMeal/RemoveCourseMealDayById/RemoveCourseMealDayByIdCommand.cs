using MediatR;

namespace FoodBackend.UseCases.CourseMeal.RemoveCourseMealDayById;

/// <summary>
/// Delete course meal day by id command.
/// </summary>
/// <param name="CourseMealDayId">Course meal day id.</param>
public record RemoveCourseMealDayByIdCommand(Guid CourseMealDayId) : IRequest;
