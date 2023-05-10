namespace FoodBackend.UseCases.Common.Dtos;

public record LightCourseMealDayDto
{
    /// <summary>
    /// Course meal day id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Id of user who created course meal day.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Course meal date.
    /// </summary>
    public DateOnly CourseMealDate { get; init; }

    /// <summary>
    /// Course meals for current day.
    /// </summary>
    public ICollection<LightCourseMealDto> CourseMeals { get; init; }
}
