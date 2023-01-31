using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Domain.MealStuffs;
using Microsoft.EntityFrameworkCore;

namespace FoodBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Abstraction for food assistant database context.
/// </summary>
public interface IFoodDbContext : IDisposable
{
    /// <summary>
    /// Food elementaries.
    /// </summary>
    DbSet<FoodElementary> FoodElementaries { get; }
    
    /// <summary>
    /// Weight of consumed food elementaries.
    /// </summary>
    DbSet<ConsumedElementaryWeight> ConsumedElementaryWeights { get; }
    
    /// <summary>
    /// Food recipes.
    /// </summary>
    DbSet<FoodRecipe> FoodRecipes { get; }
    
    /// <summary>
    /// Consumed food recipes weight.
    /// </summary>
    DbSet<ConsumedRecipeWeight> ConsumedRecipeWeights { get; }

    /// <summary>
    /// Weight of ingredients in recipe.
    /// </summary>
    DbSet<FoodElementaryWeight> FoodElementaryWeights { get; }

    /// <summary>
    /// Food characteristics.
    /// </summary>
    DbSet<FoodCharacteristic> FoodCharacteristics { get; }

    /// <summary>
    /// Food characteristic types.
    /// </summary>
    DbSet<FoodCharacteristicType> FoodCharacteristicTypes { get; }
    
    /// <summary>
    /// Course meals.
    /// </summary>
    DbSet<CourseMeal> CourseMeals { get; }

    /// <summary>
    /// Meal types.
    /// </summary>
    DbSet<MealType> MealTypes { get; }
    
    /// <summary>
    /// Save pending changes.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
