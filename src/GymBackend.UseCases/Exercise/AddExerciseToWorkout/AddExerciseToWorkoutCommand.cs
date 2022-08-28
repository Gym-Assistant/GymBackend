using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GymBackend.UseCases.Exercise.AddExerciseToWorkout;

/// <summary>
/// Add exercise to workout.
/// </summary>
public record AddExerciseToWorkoutCommand : IRequest
{
    /// <summary>
    /// Exercise id.
    /// </summary>
    [Required]
    public Guid ExerciseId { get; init; }

    /// <summary>
    /// Workout id.
    /// </summary>
    [Required]
    public Guid WorkoutId { get; init; }
}
