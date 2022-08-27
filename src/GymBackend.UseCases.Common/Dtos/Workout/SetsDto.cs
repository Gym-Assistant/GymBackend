namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Set dto.
/// </summary>
public record SetsDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

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
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
