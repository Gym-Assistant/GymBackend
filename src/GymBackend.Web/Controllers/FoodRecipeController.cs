using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodRecipe.AddIngredientToRecipe;
using FoodBackend.UseCases.FoodRecipe.CreateFoodRecipe;
using FoodBackend.UseCases.FoodRecipe.DeleteFoodRecipeById;
using FoodBackend.UseCases.FoodRecipe.EditFoodRecipe;
using FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipe;
using FoodBackend.UseCases.FoodRecipe.GetFoodRecipeById;
using FoodBackend.UseCases.FoodRecipe.RemoveIngredientFromRecipe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Food recipe controller.
/// </summary>
[ApiController]
[Route("api/foodrecipe")]
[ApiExplorerSettings(GroupName = "FoodRecipe")]
public class FoodRecipeController
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodRecipeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all food recipes.
    /// </summary>
    /// <param name="query">Query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paged list.</returns>
    [HttpGet]
    public async Task<PagedListMetadataDto<LightFoodRecipeDto>> GetAllFoodRecipes([FromQuery] GetAllFoodRecipesQuery query,
        CancellationToken cancellationToken)
        => await mediator.Send(query, cancellationToken);

    /// <summary>
    /// Get food recipe by id.
    /// </summary>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Food recipe by entered id.</returns>
    [HttpGet("{foodRecipeId}")]
    public async Task<LightFoodRecipeDto> GetFoodRecipeById(Guid foodRecipeId, CancellationToken cancellationToken)
        => await mediator.Send(new GetFoodRecipeByIdQuery(foodRecipeId), cancellationToken);

    /// <summary>
    /// Create new food recipe.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Id of created food recipe.</returns>
    [HttpPost]
    [Authorize]
    public async Task<Guid> CreateFoodRecipe(CreateFoodRecipeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Edit food recipe.
    /// </summary>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodRecipeId}")]
    [Authorize]
    public async Task EditFoodRecipe(Guid foodRecipeId, EditFoodRecipeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { Id = foodRecipeId }, cancellationToken);

    /// <summary>
    /// Remove food recipe by id.
    /// </summary>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodRecipeId}")]
    [Authorize]
    public async Task RemoveFoodRecipe(Guid foodRecipeId, CancellationToken cancellationToken) =>
        await mediator.Send(new RemoveFoodRecipeByIdCommand(foodRecipeId), cancellationToken);

    /// <summary>
    /// Add food elementary to recipe.
    /// </summary>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{foodRecipeId}/ingredients")]
    [ApiExplorerSettings(GroupName = "ChangeFoodRecipe")]
    [Authorize]
    public async Task AddIngredientToFoodRecipe(Guid foodRecipeId, AddIngredientToRecipeCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command with { FoodRecipeId = foodRecipeId }, cancellationToken);

    /// <summary>
    /// Remove food elementary from recipe.
    /// </summary>
    /// <param name="foodRecipeId">Food recipe id.</param>
    /// <param name="foodElementaryId">Food elementary id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{foodRecipeId}/ingredients/{foodElementaryId}")]
    [ApiExplorerSettings(GroupName = "ChangeFoodRecipe")]
    [Authorize]
    public async Task RemoveIngredientFromFoodRecipe(Guid foodRecipeId, Guid foodElementaryId, CancellationToken cancellationToken)
        => await mediator.Send(new RemoveIngredientFromRecipeCommand(foodRecipeId, foodElementaryId), cancellationToken);
}
