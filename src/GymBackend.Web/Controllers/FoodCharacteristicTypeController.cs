using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristicType;
using FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristicType;
using FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristicTypes;
using FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicTypeById;
using FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicTypeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Food characteristic type controller.
/// </summary>
[ApiController]
[Route("api/foodcharacteristictype")]
[ApiExplorerSettings(GroupName = "FoodCharacteristicType")]
public class FoodCharacteristicTypeController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodCharacteristicTypeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all food characteristic types.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<FoodCharacteristicTypeDto>> GetAllFoodCharacteristicType(
        [FromQuery] GetAllFoodCharacteristicTypesQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get food characteristic type by id.
    /// </summary>
    /// <param name="foodCharacteristicTypeId">Food characteristic type id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Food characteristic type by entered id.</returns>
    [HttpGet("{foodCharacteristicTypeId}")]
    public async Task<FoodCharacteristicTypeDto> GetFoodCharacteristicTypeById(
        Guid foodCharacteristicTypeId, CancellationToken cancellationToken)
        => await mediator.Send(new GetFoodCharacteristicTypeByIdQuery(foodCharacteristicTypeId), cancellationToken);

    /// <summary>
    /// Create new food characteristic type.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Id of created food characteristic type.</returns>
    [HttpPost]
    [Authorize]
    public async Task<Guid> CreateFoodCharacteristicType(
        CreateFoodCharacteristicTypeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit food characteristic type.
    /// </summary>
    /// <param name="foodCharacteristicTypeId">Food characteristic type id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodCharacteristicTypeId}")]
    [Authorize]
    public async Task EditFoodCharacteristicType(Guid foodCharacteristicTypeId,
        EditFoodCharacteristicTypeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { FoodCharacteristicTypeId = foodCharacteristicTypeId }, cancellationToken);

    /// <summary>
    /// Remove food characteristic type by id.
    /// </summary>
    /// <param name="foodCharacteristicTypeId">Food characteristic type id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodCharacteristicTypeId}")]
    [Authorize]
    public async Task RemoveFoodCharacteristicTypeById(Guid foodCharacteristicTypeId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveFoodCharacteristicTypeByIdCommand(foodCharacteristicTypeId), cancellationToken);
}
