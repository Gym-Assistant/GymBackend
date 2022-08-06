using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Exercise.
/// </summary>
public record Exercise
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// Name of exercise.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Description of exercise.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Train session.
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
    /// Related workouts.
    /// </summary>
    public ICollection<Workout> Workouts { get; init; }
}