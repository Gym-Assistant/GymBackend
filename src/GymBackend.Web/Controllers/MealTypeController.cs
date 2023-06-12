using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.MealType.CreateMealType;
using FoodBackend.UseCases.MealType.EditMealType;
using FoodBackend.UseCases.MealType.GetAllMealTypes;
using FoodBackend.UseCases.MealType.GetMealTypeById;
using FoodBackend.UseCases.MealType.RemoveMealTypeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Meal type controller.
/// </summary>
[ApiController]
[Route("api/mealtype")]
[ApiExplorerSettings(GroupName = "MealTypes")]
[Authorize]
public class MealTypeController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public MealTypeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all meal types.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightMealTypeDto>> GetAllMealsTypes([FromQuery] GetAllMealTypesQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get meal type by id.
    /// </summary>
    /// <param name="mealTypeId">Meal type id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Meal type.</returns>
    [HttpGet("{mealTypeId}")]
    public async Task<LightMealTypeDto> GetMealTypesById(Guid mealTypeId, CancellationToken cancellationToken)
        => await mediator.Send(new GetMealTypeByIdQuery(mealTypeId), cancellationToken);

    /// <summary>
    /// Create new meal type.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Guid> CreateMealType(CreateMealTypeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit meal type by id.
    /// </summary>
    /// <param name="mealTypeId">Meal type id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{mealTypeId}")]
    public async Task EditMealType(Guid mealTypeId, EditMealTypeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { MealTypeId = mealTypeId }, cancellationToken);

    /// <summary>
    /// Remove meal type by id.
    /// </summary>
    /// <param name="mealTypeId">Meal type id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{mealTypeId}")]
    public async Task RemoveMealType(Guid mealTypeId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveMealTypeByIdCommand(mealTypeId), cancellationToken);
}
