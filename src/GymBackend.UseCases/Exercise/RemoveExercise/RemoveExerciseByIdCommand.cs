using MediatR;

namespace GymBackend.UseCases.Exercise.RemoveExercise;

/// <summary>
/// Remove exercise command.
/// </summary>
/// <param name="ExerciseId">Exercise Id.</param>
public record RemoveExerciseByIdCommand(Guid ExerciseId) : IRequest;
