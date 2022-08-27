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
    public Guid Id { get; set; }

    /// <summary>
    /// Exercises.
    /// </summary>
    public ICollection<Exercise> Exercises { get; set; }

    /// <summary>
    /// Train session in this workout.
    /// </summary>
    public ICollection<TrainSession> TrainSessions { get; set; }

    /// <summary>
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Created by.
    /// </summary>
    public User CreatedBy { get; set; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Workout status.
    /// </summary>
    public WorkoutStatus WorkoutStatus { get; set; }
}
