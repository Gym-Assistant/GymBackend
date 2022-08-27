using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;

namespace GymBackend.UseCases.Workout.GetWorkoutById;

/// <summary>
/// Get workout by id.
/// </summary>
public record GetWorkoutByIdQuery : IRequest<WorkoutDto>
{
    /// <summary>
    /// Workout id.
    /// </summary>
    public Guid WorkoutId { get; init; }
}
