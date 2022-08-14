using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Workout.
/// </summary>
public record Workout
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// Exercises.
    /// </summary>
    public ICollection<Exercise> Exercises { get; init; }

    /// <summary>
    /// Train session in this workout.
    /// </summary>
    public ICollection<TrainSession> TrainSessions { get; init; }

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

    /// <summary>
    /// Workout status.
    /// </summary>
    public WorkoutStatus WorkoutStatus { get; init; }
}
