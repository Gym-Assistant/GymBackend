using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.Dtos.Workout;
using GymBackend.UseCases.Workout.GetAllWorkouts;
using GymBackend.UseCases.Workout.GetWorkoutById;
using GymBackend.UseCases.Workout.RemoveWorkout;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Workout controller.
/// </summary>
[ApiController]
[Route("api/workout")]
[ApiExplorerSettings(GroupName = "Workout")]
[Authorize]
public class WorkoutController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public WorkoutController(IMediator mediator, ILoggedUserAccessor loggedUserAccessor)
    {
        this.mediator = mediator;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <summary>
    /// Get all workouts.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list workout.</returns>
    [HttpGet]
    public async Task<IEnumerable<WorkoutDto>> GetWorkouts([FromQuery] GetAllWorkoutsQuery query, CancellationToken cancellationToken)
    {
        query = query with { UserId = loggedUserAccessor.GetCurrentUserId() };
        return await mediator.Send(query, cancellationToken);
    }

    /// <summary>
    /// Get workout by WorkoutId.
    /// </summary>
    /// <returns>Workout.</returns>
    [HttpGet("{workoutId}")]
    public async Task<WorkoutDto> GetWorkoutById([FromRoute] Guid workoutId, CancellationToken cancellationToken) =>
        await mediator.Send(new GetWorkoutByIdQuery { WorkoutId = workoutId }, cancellationToken);

    /// <summary>
    /// Remove workout by Id.
    /// </summary>
    /// <param name="workoutId">WorkoutId.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{workoutId}")]
    public async Task RemoveWorkoutById([FromRoute] Guid workoutId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveWorkoutByIdCommand(workoutId), cancellationToken);
}
