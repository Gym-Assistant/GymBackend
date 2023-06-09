using Gym.Domain.Meta;
using GymBackend.Domain.Workouts;

namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Workout dto.
/// </summary>
public record WorkoutDto : ICreatableNullable, IUpdatable
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Train session in this workout.
    /// </summary>
    public ICollection<TrainSession> TrainSessions { get; set; } = new List<TrainSession>();

    /// <summary>
    /// Started at.
    /// </summary>
    public DateTimeOffset? StartedAt { get; set; }

    /// <summary>
    /// Ended at.
    /// </summary>
    public DateTimeOffset? EndedAt { get; set; }

    /// <summary>
    /// Workout type.
    /// </summary>
    public WorkoutType WorkoutType { get; set; }

    #region Metadata

    /// <inheritdoc />
    public Guid? CreatedById { get; set; }

    /// <inheritdoc />
    public Domain.Users.User CreatedBy { get; set; }

    /// <inheritdoc />
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset UpdatedAt { get; set; }

    #endregion
}
