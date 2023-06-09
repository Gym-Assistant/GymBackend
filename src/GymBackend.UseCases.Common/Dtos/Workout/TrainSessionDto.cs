namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Train session dto.
/// </summary>
public record TrainSessionDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Exercise Id.
    /// </summary>
    public Guid ExerciseId { get; set; }

    /// <summary>
    /// Sets.
    /// </summary>
    public ICollection<SetDto> Sets { get; set; } = new List<SetDto>();

    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; set; }

    /// <summary>
    /// When train session started.
    /// </summary>
    public DateTimeOffset? StartedAt { get; set; }

    /// <summary>
    /// When train session ended.
    /// </summary>
    public DateTimeOffset? EndedAt { get; set; }

    /// <summary>
    /// Number in workout.
    /// </summary>
    public int Number { get; internal set; }

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
