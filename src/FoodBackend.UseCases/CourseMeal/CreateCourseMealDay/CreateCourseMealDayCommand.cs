using MediatR;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMealDay;

/// <summary>
/// Create course meal day command.
/// </summary>
public record CreateCourseMealDayCommand() : IRequest<Guid>;
