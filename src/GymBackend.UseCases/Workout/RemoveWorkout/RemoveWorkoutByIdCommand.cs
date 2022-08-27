using MediatR;

namespace GymBackend.UseCases.Workout.RemoveWorkout;

/// <summary>
/// Remove workout by id.
/// </summary>
/// <param name="WorkoutId">Workout Id.</param>
public record RemoveWorkoutByIdCommand(Guid WorkoutId) : IRequest;
