using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;

namespace GymBackend.UseCases.Workout.AddWorkouts;

/// <summary>
/// Add workouts command.
/// </summary>
public record AddWorkoutsCommand : IRequest
{
    /// <summary>
    /// Workouts.
    /// </summary>
    public IEnumerable<WorkoutDto> Workouts { get; set; }
}