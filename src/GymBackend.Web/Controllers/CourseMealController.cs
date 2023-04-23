using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.CourseMeal.AddCourseMealToDay;
using FoodBackend.UseCases.CourseMeal.AddElementaryToCourseMeal;
using FoodBackend.UseCases.CourseMeal.AddRecipeToCourseMeal;
using FoodBackend.UseCases.CourseMeal.CreateCourseMeal;
using FoodBackend.UseCases.CourseMeal.CreateCourseMealDay;
using FoodBackend.UseCases.CourseMeal.EditCourseMeal;
using FoodBackend.UseCases.CourseMeal.GetAllCourseMeal;
using FoodBackend.UseCases.CourseMeal.GetCourseMealById;
using FoodBackend.UseCases.CourseMeal.RemoveCourseMealById;
using FoodBackend.UseCases.CourseMeal.RemoveCourseMealDayById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Course meal controller.
/// </summary>
[ApiController]
[Route("api/coursemeal")]
[ApiExplorerSettings(GroupName = "CourseMeals")]
[Authorize]
public class CourseMealController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CourseMealController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all course meals.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightCourseMealDto>> GetAllCourseMeals([FromQuery] GetAllCourseMealQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get course meal by id.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Exercise.</returns>
    [HttpGet("{courseMealId}")]
    public async Task<LightCourseMealDto> GetCourseMealById(Guid courseMealId, CancellationToken cancellationToken)
        => await mediator.Send(new GetCourseMealByIdQuery(courseMealId), cancellationToken);

    /// <summary>
    /// Create new course meal.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Guid> CreateCourseMeal(CreateCourseMealCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit course meal by id.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{courseMealId}")]
    public async Task EditCourseMeal(Guid courseMealId, EditCourseMealCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { CourseMealId = courseMealId }, cancellationToken);

    /// <summary>
    /// Remove course meal by id.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{courseMealId}")]
    public async Task RemoveCourseMeal(Guid courseMealId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveCourseMealByIdCommand(courseMealId), cancellationToken);

    /// <summary>
    /// Add food elementary to course meal.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{courseMealId}/addfoodelementary")]
    [ApiExplorerSettings(GroupName = "ChangeCourseMeal")]
    public async Task AddFoodElementaryToCourseMeal(Guid courseMealId, AddElementaryToCourseMealCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { CourseMealId = courseMealId }, cancellationToken);

    /// <summary>
    /// Add food recipe to course meal.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{courseMealId}/addrecipe")]
    [ApiExplorerSettings(GroupName = "ChangeCourseMeal")]
    public async Task AddFoodRecipeToCourseMeal(Guid courseMealId, AddRecipeToCourseMealCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { CourseMealId = courseMealId }, cancellationToken);

    /// <summary>
    /// Create new course meal day.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost("coursemealday")]
    [ApiExplorerSettings(GroupName = "CourseMealDay")]
    public async Task<Guid> CreateCourseMealDay(CancellationToken cancellationToken)
        => await mediator.Send(new CreateCourseMealDayCommand(), cancellationToken);

    /// <summary>
    /// Add course meal to day.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <param name="courseMealDayId">Course meal day id.</param>
    [HttpPut("coursemealday/{courseMealDayId}")]
    [ApiExplorerSettings(GroupName = "CourseMealDay")]
    public async Task AddCourseMealToDay(Guid courseMealDayId, AddCourseMealToDayCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { CourseMealDayId = courseMealDayId }, cancellationToken);

    /// <summary>
    /// Delete course meal day.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <param name="courseMealDayId">Course meal day id.</param>
    [HttpDelete("coursemealday/{courseMealDayId}")]
    [ApiExplorerSettings(GroupName = "CourseMealDay")]
    public async Task RemoveCourseMealDay(Guid courseMealDayId, CancellationToken cancellationToken)
        => await mediator.Send(new RemoveCourseMealDayByIdCommand(courseMealDayId), cancellationToken);
}
