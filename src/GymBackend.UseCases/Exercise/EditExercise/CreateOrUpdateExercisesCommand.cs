using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;

namespace GymBackend.UseCases.Exercise.EditExercise;

/// <summary>
/// Edit exercise command.
/// </summary>
public record CreateOrUpdateExercisesCommand : IRequest
{
    /// <summary>
    /// Exercises.
    /// </summary>
    public IEnumerable<LightExerciseDto> Exercises { get; set; }
}
