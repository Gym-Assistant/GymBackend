using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.Dtos.Workout;
using GymBackend.UseCases.Exercise.CreateExercise;
using GymBackend.UseCases.Exercise.EditExercise;
using GymBackend.UseCases.Exercise.GetAllExercises;
using GymBackend.UseCases.Exercise.GetExerciseById;
using GymBackend.UseCases.Exercise.RemoveExercise;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Exercise controller.
/// </summary>
[ApiController]
[Route("api/exercise")]
[ApiExplorerSettings(GroupName = "Exercises")]
[Authorize]
public class ExerciseController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ExerciseController(ILoggedUserAccessor loggedUserAccessor, IMediator mediator)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all exercises.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightExerciseDto>> GetAllExercises([FromQuery] GetAllExercisesQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);


    /// <summary>
    /// Get exerciseId by exerciseId.
    /// </summary>
    /// <param name="exerciseId">Exercise exerciseId.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Exercise.</returns>
    [HttpGet("{exerciseId}")]
    public async Task<LightExerciseDto> GetExerciseById(Guid exerciseId, CancellationToken cancellationToken)
        => await mediator.Send(new GetExerciseByIdQuery(exerciseId), cancellationToken);

    /// <summary>
    /// Create new exerciseId.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Guid> CreateExercise(CreateExerciseCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit exerciseId by id.
    /// </summary>
    /// <param name="exerciseId">Exercise Id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{exerciseId}")]
    public async Task EditExercise(Guid exerciseId, EditExerciseCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { Id = exerciseId }, cancellationToken);

    /// <summary>
    /// Remove exercise by id.
    /// </summary>
    /// <param name="exerciseId">Exercise Id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{exerciseId}")]
    public async Task RemoveExercise(Guid exerciseId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveExerciseByIdCommand(exerciseId), cancellationToken);
}
