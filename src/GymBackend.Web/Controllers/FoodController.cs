using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Food.CreateFood;
using FoodBackend.UseCases.Food.DeleteFoodById;
using FoodBackend.UseCases.Food.EditFood;
using FoodBackend.UseCases.Food.GetAllFood;
using FoodBackend.UseCases.Food.GetFoodById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Food controller.
/// </summary>
[ApiController]
[Route("api/food")]
[ApiExplorerSettings(GroupName = "Food")]
public class FoodController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all food.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightFoodDto>> GetAllFood([FromQuery] GetAllFoodQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get food by id.
    /// </summary>
    /// <param name="foodId">Food id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Food by entered id.</returns>
    [HttpGet("{foodId}")]
    public async Task<LightFoodDto> GetAllFood(Guid foodId, CancellationToken cancellationToken)
        => await mediator.Send(new GetFoodByIdQuery(foodId), cancellationToken);

    /// <summary>
    /// Create new Food.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Id of created food.</returns>
    [HttpPost]
    [Authorize]
    public async Task<Guid> CreateFood(CreateFoodCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit food by id.
    /// </summary>
    /// <param name="foodId">Food id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodId}")]
    [Authorize]
    public async Task EditFood(Guid foodId, EditFoodCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { Id = foodId }, cancellationToken);

    /// <summary>
    /// Remove food by id.
    /// </summary>
    /// <param name="foodId">Food id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodId}")]
    [Authorize]
    public async Task RemoveFood(Guid foodId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveFoodByIdCommand(foodId), cancellationToken);
}
