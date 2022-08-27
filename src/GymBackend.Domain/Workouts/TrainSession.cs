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
    public Guid Id { get; set; }

    /// <summary>
    /// Exercise Id.
    /// </summary>
    public Guid ExerciseId { get; set; }

    /// <summary>
    /// Related exercise.
    /// </summary>
    public Exercise Exercise { get; set; }

    /// <summary>
    /// Sets.
    /// </summary>
    public ICollection<Sets> Sets { get; set; }

    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; set; }

    /// <summary>
    /// Related workout.
    /// </summary>
    public Workout Workout { get; set; }

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
}
