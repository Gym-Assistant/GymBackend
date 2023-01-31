using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodElementary.CreateFoodElementary;
using FoodBackend.UseCases.FoodElementary.DeleteFoodElementaryById;
using FoodBackend.UseCases.FoodElementary.EditFoodElementary;
using FoodBackend.UseCases.FoodElementary.GetAllFoodElementaries;
using FoodBackend.UseCases.FoodElementary.GetFoodElementaryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Food elementary controller.
/// </summary>
[ApiController]
[Route("api/foodelementary")]
[ApiExplorerSettings(GroupName = "FoodElementary")]
public class FoodElementaryController
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodElementaryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all food elementaries.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightFoodElementaryDto>> GetAllFoodElementaries([FromQuery] GetAllFoodElementariesQuery query,
        CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get food elementary by id.
    /// </summary>
    /// <param name="foodElementaryId">Food elementary id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Food elementary by entered id.</returns>
    [HttpGet("{foodElementaryId}")]
    public async Task<LightFoodElementaryDto> GetFoodElementaryById(Guid foodElementaryId, CancellationToken cancellationToken)
        => await mediator.Send(new GetFoodElementaryByIdQuery(foodElementaryId), cancellationToken);

    /// <summary>
    /// Create new food elementary.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Id of created food elementary.</returns>
    [HttpPost]
    [Authorize]
    public async Task<Guid> CreateFoodElementary(CreateFoodElementaryCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit food elementary.
    /// </summary>
    /// <param name="foodElementaryId">Food elementary id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodElementaryId}")]
    [Authorize]
    public async Task EditFoodElementary(Guid foodElementaryId, EditFoodElementaryCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { Id = foodElementaryId }, cancellationToken);

    /// <summary>
    /// Remove food elementary by id.
    /// </summary>
    /// <param name="foodElementaryId">Food elementary id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodElementaryId}")]
    [Authorize]
    public async Task RemoveFoodElementary(Guid foodElementaryId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveFoodElementaryByIdCommand(foodElementaryId), cancellationToken);
}
