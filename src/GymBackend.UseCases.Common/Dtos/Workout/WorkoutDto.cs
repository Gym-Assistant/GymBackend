using GymBackend.Domain.Workouts;

namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Workout dto.
/// </summary>
public record WorkoutDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Exercises.
    /// </summary>
    public ICollection<LightExerciseDto> Exercises { get; init; }

    /// <summary>
    /// Train session in this workout.
    /// </summary>
    public ICollection<TrainSessionDto> TrainSessions { get; init; }

    /// <summary>
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; init; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
