using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Sets.
/// </summary>
public record Sets
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// Train session Id.
    /// </summary>
    public Guid TrainSessionId { get; init; }

    /// <summary>
    /// Train session.
    /// </summary>
    public TrainSession TrainSession { get; init; }

    /// <summary>
    /// Number of repetitions.
    /// </summary>
    public int Reps { get; init; }

    /// <summary>
    /// The weight of the projectile.
    /// </summary>
    public double Weight { get; init; }

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