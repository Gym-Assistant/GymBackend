namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Course meal DTO with detail information.
/// </summary>
public record DetailCourseMealDto
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
    /// Consumed food elementaries.
    /// </summary>
    public ICollection<FoodElementaryInCourseMealDto> ConsumedElementaries { get; init; }
    
    /// <summary>
    /// Consumed food recipes.
    /// </summary>
    public ICollection<RecipeInCourseMealDto> ConsumedRecipes { get; init; }
    
    /// <summary>
    /// Course meal food characteristics sum values.
    /// </summary>
    public ICollection<FoodCharacteristicSumDto> CharacteristicsSum { get; set; }

    /// <summary>
    /// Time when meal was created.
    /// </summary>
    public TimeOnly CreationTime { get; init; }
    
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; init; }
    
    /// <summary>
    /// Meal type name.
    /// </summary>
    public string MealTypeName { get; init; }

    /// <summary>
    /// Course meal day id.
    /// </summary>
    public Guid CourseMealDayId { get; init; }
}
