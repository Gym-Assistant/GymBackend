using MediatR;

namespace GymBackend.UseCases.Workout.StartWorkout;

/// <summary>
/// Start workout command.
/// </summary>
public record StartWorkoutCommand() : IRequest<Guid>;
