using GymBackend.Domain.Workouts;
using GymBackend.UseCases.Common.Dtos.User;

namespace GymBackend.UseCases.Common.Dtos.Workout;

/// <summary>
/// Light workout dto.
/// </summary>
public record LightWorkoutDto
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
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
