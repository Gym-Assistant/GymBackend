using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristic;
using FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristic;
using FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristic;
using FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicById;
using FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Food characteristic controller.
/// </summary>
[ApiController]
[Route("api/foodcharacteristic")]
[ApiExplorerSettings(GroupName = "FoodCharacteristic")]
public class FoodCharacteristicController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodCharacteristicController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all food characteristics.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightFoodCharacteristicDto>> GetAllFoodCharacteristic(
        [FromQuery] GetAllFoodCharacteristicsQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get food characteristic by id.
    /// </summary>
    /// <param name="foodCharacteristicId">Food characteristic id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Food characteristic by entered id.</returns>
    [HttpGet("{foodCharacteristicId}")]
    public async Task<LightFoodCharacteristicDto> GetFoodCharacteristicById(
        Guid foodCharacteristicId, CancellationToken cancellationToken)
        => await mediator.Send(new GetFoodCharacteristicByIdQuery(foodCharacteristicId), cancellationToken);

    /// <summary>
    /// Create new food characteristic.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Id of created food characteristic.</returns>
    [HttpPost]
    [Authorize]
    public async Task<Guid> CreateFoodCharacteristic(
        CreateFoodCharacteristicCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit food characteristic.
    /// </summary>
    /// <param name="foodCharacteristicId">Food characteristic id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodCharacteristicId}")]
    [Authorize]
    public async Task EditFoodCharacteristic(Guid foodCharacteristicId,
        EditFoodCharacteristicCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { FoodCharacteristicId = foodCharacteristicId }, cancellationToken);

    /// <summary>
    /// Remove food characteristic by id.
    /// </summary>
    /// <param name="foodCharacteristicId">Food characteristic id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodCharacteristicId}")]
    [Authorize]
    public async Task RemoveFoodCharacteristicById(Guid foodCharacteristicId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveFoodCharacteristicByIdCommand(foodCharacteristicId), cancellationToken);
}
