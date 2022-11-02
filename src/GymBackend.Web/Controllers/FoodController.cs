using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Food.AddFood;
using FoodBackend.UseCases.Food.DeleteFood;
using FoodBackend.UseCases.Food.GetAllFoods;
using FoodBackend.UseCases.Food.GetFoodById;
using FoodBackend.UseCases.Food.UpdateFood;
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
[Authorize]
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
    /// Create new food.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost]
    public async Task<Guid> CreateFood(CreateFoodCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Get all foods.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<PagedListMetadataDto<LightFoodDto>> GetAllFoods([FromQuery] GetAllFoodsQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get food by id.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [AllowAnonymous]
    [HttpGet("{foodId}")]
    public async Task<LightFoodDto> GetFoodById(Guid foodId, CancellationToken cancellationToken)
        => await mediator.Send(new GetFoodByIdQuery(foodId), cancellationToken);

    /// <summary>
    /// Update selected food.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodId}")]
    public async Task CreateFood(Guid foodId, UpdateFoodCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { Id = foodId }, cancellationToken);

    /// <summary>
    /// Delete selected food.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodId}")]
    public async Task CreateFood(Guid foodId, CancellationToken cancellationToken)
        => await mediator.Send(new DeleteFoodCommand(foodId), cancellationToken);
}
