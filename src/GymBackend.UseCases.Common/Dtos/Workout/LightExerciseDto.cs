namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Light exercise dto.
/// </summary>
public record LightExerciseDto
{
    /// <summary>
    /// Id.
    /// </summary>
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
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; init; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
