namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Course meal DTO with detail information.
/// </summary>
public record DetailCourseMealDto
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id of user who created course meal.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Consumed food elementaries.
    /// </summary>
    public ICollection<LightFoodElementaryDto> ConsumedFoodElementaries { get; set; }
    
    /// <summary>
    /// Consumed food elementaries weight.
    /// </summary>
    public ICollection<ConsumedElementaryWeightDto> ConsumedElementaryWeights { get; set; }
    
    /// <summary>
    /// Consumed food recipes.
    /// </summary>
    public ICollection<LightFoodRecipeDto> ConsumedFoodRecipes { get; set; }
    
    /// <summary>
    /// Consumed food recipes weight.
    /// </summary>
    public ICollection<ConsumedRecipeWeightDto> ConsumedRecipeWeights { get; set; }

    /// <summary>
    /// Time when meal was created.
    /// </summary>
    public TimeOnly CreatedAt { get; set; }
    
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; set; }

    /// <summary>
    /// Course meal day id.
    /// </summary>
    public Guid CourseMealDayId { get; set; }
}
