namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Train session dto.
/// </summary>
public record TrainSessionDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Related exercise.
    /// </summary>
    public LightExerciseDto Exercise { get; init; }

    /// <summary>
    /// Sets.
    /// </summary>
    public ICollection<SetsDto> Sets { get; init; }

    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; init; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; init; }
}
