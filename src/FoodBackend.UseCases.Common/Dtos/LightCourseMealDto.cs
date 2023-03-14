namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Light course meal DTO with minimum information.
/// </summary>
public class LightCourseMealDto
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Id of user who created course meal.
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; init; }
    
    /// <summary>
    /// Date when meal was created.
    /// </summary>
    public DateTime CreationTime { get; init; }
}
