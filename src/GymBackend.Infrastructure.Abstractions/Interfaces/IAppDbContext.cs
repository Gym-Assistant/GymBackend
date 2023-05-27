using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Domain.MealStuffs;
using GymBackend.Domain.Users;
using GymBackend.Domain.Workouts;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Application abstraction for unit of work.
/// </summary>
public interface IAppDbContext : IDisposable
{
    /// <summary>
    /// Users.
    /// </summary>
    DbSet<User> Users { get; }

    /// <summary>
    /// User characteristic set.
    /// </summary>
    DbSet<UserCharacteristic> UserCharacteristics { get; }

    /// <summary>
    /// Characteristic stamp.
    /// </summary>
    DbSet<CharacteristicStamp> CharacteristicStamps { get; }

    /// <summary>
    /// Workout.
    /// </summary>
    DbSet<Workout> Workouts { get; }

    /// <summary>
    /// Exercises.
    /// </summary>
    DbSet<Exercise> Exercises { get; }

    /// <summary>
    /// Training sessions.
    /// </summary>
    DbSet<TrainSession> TrainSessions { get; }

    /// <summary>
    /// Workout templates.
    /// </summary>
    DbSet<WorkoutTemplate> WorkoutTemplates { get; }

    /// <summary>
    /// Workout packages.
    /// </summary>
    DbSet<WorkoutPackage> WorkoutPackages { get; }

    /// <summary>
    /// Sets.
    /// </summary>
    DbSet<Set> Sets { get; }

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
    /// Course meal days.
    /// </summary>
    DbSet<CourseMealDay> CourseMealDays { get; }

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
