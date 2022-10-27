using FoodBackend.UseCases.Food.AddFood;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
}
