namespace FoodBackend.UseCases.Common.Dtos;

public record LightCourseMealDayDto
{
    /// <summary>
    /// Course meal day id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id of user who created course meal day.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Course meal date.
    /// </summary>
    public DateOnly CourseMealDate { get; set; }

    /// <summary>
    /// Course meals for current day.
    /// </summary>
    public ICollection<LightCourseMealDto> CourseMeals { get; set; }
}
