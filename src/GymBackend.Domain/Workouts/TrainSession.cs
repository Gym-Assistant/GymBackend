using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Train session.
/// </summary>
public record TrainSession
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// Exercise Id.
    /// </summary>
    public Guid ExerciseId { get; init; }

    /// <summary>
    /// Related exercise.
    /// </summary>
    public Exercise Exercise { get; init; }

    /// <summary>
    /// Sets.
    /// </summary>
    public ICollection<Sets> Sets { get; init; }

    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; init; }

    /// <summary>
    /// Related workout.
    /// </summary>
    public Workout Workout { get; init; }

    /// <summary>
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; init; }

    /// <summary>
    /// Created by.
    /// </summary>
    public User CreatedBy { get; init; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}