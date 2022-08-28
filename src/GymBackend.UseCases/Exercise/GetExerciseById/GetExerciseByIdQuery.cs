using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;

namespace GymBackend.UseCases.Exercise.GetExerciseById;

/// <summary>
/// Get Exercise by id.
/// </summary>
/// <param name="ExerciseId">Exercise Id.</param>
public record GetExerciseByIdQuery(Guid ExerciseId) : IRequest<LightExerciseDto>;
