using System.ComponentModel.DataAnnotations;
using Gym.Domain.Meta;
using GymBackend.Domain.Meta;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Exercise.
/// </summary>
public record Exercise : ICreatable, IUpdatable
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Name of exercise.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of exercise.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Train session.
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
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset UpdatedAt { get; set; }
}
