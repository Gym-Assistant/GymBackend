using GymBackend.Domain.FoodRecords;
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
    DbSet<Sets> Sets { get; }

    /// <summary>
    /// Foods set.
    /// </summary>
    DbSet<Food> Foods { get; }

    /// <summary>
    /// Save pending changes.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
