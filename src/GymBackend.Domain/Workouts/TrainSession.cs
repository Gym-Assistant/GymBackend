using System.ComponentModel.DataAnnotations;
using Gym.Domain.Meta;
using GymBackend.Domain.Meta;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Train session.
/// </summary>
public record TrainSession : ICreatable, IUpdatable
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; private set; }

    /// <summary>
    /// Exercise Id.
    /// </summary>
    public Guid ExerciseId { get; private set; }

    /// <summary>
    /// Related exercise.
    /// </summary>
    public Exercise Exercise { get; private set; }

    /// <summary>
    /// Sets.
    /// </summary>
    public ICollection<Set> Sets { get; private set; } = new List<Set>();

    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; private set; }

    /// <summary>
    /// Related workout.
    /// </summary>
    public Workout Workout { get; private set; }

    /// <summary>
    /// When train session started.
    /// </summary>
    public DateTime? StartedAt { get; private set; }

    /// <summary>
    /// When train session ended.
    /// </summary>
    public DateTime? EndedAt { get; private set; }

    /// <summary>
    /// Number in workout.
    /// </summary>
    public int Number { get; internal set; }

    /// <inheritdoc/>
    public Guid CreatedById { get; set; }

    /// <inheritdoc/>
    public User CreatedBy { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc/>
    public DateTimeOffset UpdatedAt { get; set; }
}
