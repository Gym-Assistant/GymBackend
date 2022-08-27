using MediatR;

namespace GymBackend.UseCases.Workout.EndWorkout;

/// <summary>
/// End workout command.
/// </summary>
public record EndWorkoutCommand(Guid WorkoutId) : IRequest;
