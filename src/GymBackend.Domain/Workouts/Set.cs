using System.ComponentModel.DataAnnotations;
using Gym.Domain.Meta;
using GymBackend.Domain.Meta;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Sets.
/// </summary>
public record Set : ICreatable, IUpdatable
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; private set; }

    /// <summary>
    /// Train session Id.
    /// </summary>
    public Guid TrainSessionId { get; private set; }

    /// <summary>
    /// Train session.
    /// </summary>
    public TrainSession TrainSession { get; private set; }

    /// <summary>
    /// Number of repetitions.
    /// </summary>
    public int Reps { get; private set; }

    /// <summary>
    /// The weight of the projectile.
    /// </summary>
    public double Weight { get; private set; }

    /// <summary>
    /// Indicates that set is done.
    /// </summary>
    public bool IsDone { get; private set; }

    /// <summary>
    /// Number.
    /// </summary>
    public int Number { get; internal set; }

    /// <inheritdoc/>
    public Guid CreatedById { get; set; }

    /// <inheritdoc/>
    public User CreatedBy { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset? UpdatedAt { get; set; }
}
