using System.ComponentModel.DataAnnotations;
using Gym.Domain.Meta;
using GymBackend.Domain.Meta;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Workout.
/// </summary>
public record Workout : ICreatable, IUpdatable
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; private set; }

    /// <summary>
    /// Train session in this workout.
    /// </summary>
    public ICollection<TrainSession> TrainSessions { get; private set; } = new List<TrainSession>();

    /// <summary>
    /// Started at.
    /// </summary>
    public DateTimeOffset? StartedAt { get; private set; }

    /// <summary>
    /// Ended at.
    /// </summary>
    public DateTimeOffset? EndedAt { get; private set; }

    /// <summary>
    /// Workout type.
    /// </summary>
    public WorkoutType WorkoutType { get; private set; }

    /// <inheritdoc/>
    public Guid CreatedById { get; set; }

    /// <inheritdoc/>
    public User CreatedBy { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset UpdatedAt { get; set; }
}
