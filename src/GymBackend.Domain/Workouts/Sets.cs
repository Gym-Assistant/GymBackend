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
    public Guid Id { get; set; }

    /// <summary>
    /// Train session Id.
    /// </summary>
    public Guid TrainSessionId { get; set; }

    /// <summary>
    /// Train session.
    /// </summary>
    public TrainSession TrainSession { get; set; }

    /// <summary>
    /// Number of repetitions.
    /// </summary>
    public int Reps { get; set; }

    /// <summary>
    /// The weight of the projectile.
    /// </summary>
    public double Weight { get; set; }

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
