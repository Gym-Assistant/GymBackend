using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    [JsonIgnore]
    public Guid WorkoutId { get; init; }
}
