using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.CourseMeal.AddElementaryToCourseMeal;
using FoodBackend.UseCases.CourseMeal.AddRecipeToCourseMeal;
using FoodBackend.UseCases.CourseMeal.ChangeElementaryWeightInCourseMeal;
using FoodBackend.UseCases.CourseMeal.ChangeRecipeWeightInCourseMeal;
using FoodBackend.UseCases.CourseMeal.CreateCourseMeal;
using FoodBackend.UseCases.CourseMeal.EditCourseMeal;
using FoodBackend.UseCases.CourseMeal.GetAllCourseMeal;
using FoodBackend.UseCases.CourseMeal.GetCourseMealById;
using FoodBackend.UseCases.CourseMeal.RemoveCourseMealById;
using FoodBackend.UseCases.CourseMeal.RemoveElementaryFromCourseMeal;
using FoodBackend.UseCases.CourseMeal.RemoveRecipeFromCourseMeal;
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
    /// Get all course meals with detail information.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<DetailCourseMealDto>> GetAllCourseMeals([FromQuery] GetAllCourseMealQuery query, CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get course meal day by id with detail information.
    /// </summary>
    /// <param name="courseMealId">Course meal day id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("{courseMealId}")]
    public async Task<DetailCourseMealDto> GetCourseMealById(Guid courseMealId, CancellationToken cancellationToken)
        => await mediator.Send(new GetCourseMealByIdQuery(courseMealId), cancellationToken);

    /// <summary>
    /// Create new course meal.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
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
    /// Remove food elementary from course meal.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="foodElementaryId">Food elementary id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{courseMealId}/consumedelementaries/{foodElementaryId}")]
    [ApiExplorerSettings(GroupName = "ChangeCourseMeal")]
    public async Task RemoveFoodElementaryFromCourseMeal(Guid courseMealId, Guid foodElementaryId, CancellationToken cancellationToken)
        => await mediator.Send(new RemoveElementaryFromCourseMealCommand(foodElementaryId, courseMealId), cancellationToken);

    /// <summary>
    /// Remove food recipe from course meal.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{courseMealId}/consumedrecipes/{foodRecipeId}")]
    [ApiExplorerSettings(GroupName = "ChangeCourseMeal")]
    public async Task RemoveFoodRecipeFromCourseMeal(Guid courseMealId, Guid foodRecipeId, CancellationToken cancellationToken)
        => await mediator.Send(new RemoveRecipeFromCourseMealCommand(foodRecipeId, courseMealId), cancellationToken);

    /// <summary>
    /// Change food elementary weight in course meal.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="foodElementaryId">Food elementary id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{courseMealId}/consumedelementaries/{foodElementaryId}")]
    [ApiExplorerSettings(GroupName = "ChangeCourseMeal")]
    public async Task ChangeElementaryWeightInCourseMeal(Guid courseMealId, Guid foodElementaryId,
        ChangeElementaryWeightInCourseMealCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { CourseMealId = courseMealId, FoodElementaryId = foodElementaryId},cancellationToken);

    /// <summary>
    /// Change food recipe weight in course meal.
    /// </summary>
    /// <param name="courseMealId">Course meal id.</param>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{courseMealId}/consumedrecipes/{foodRecipeId}")]
    [ApiExplorerSettings(GroupName = "ChangeCourseMeal")]
    public async Task ChangeRecipeWeightInCourseMeal(Guid courseMealId, Guid foodRecipeId,
        ChangeRecipeWeightInCourseMealCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { CourseMealId = courseMealId, FoodRecipeId = foodRecipeId},cancellationToken);
}
