using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.AddIngredientToRecipe;

/// <summary>
/// Add ingredient to recipe command handler.
/// </summary>
internal class AddIngredientToRecipeCommandHandler : IRequestHandler<AddIngredientToRecipeCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddIngredientToRecipeCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(AddIngredientToRecipeCommand request, CancellationToken cancellationToken)
    {
        var foodRecipe = await dbContext.FoodRecipes
            .Include(foodRecipe => foodRecipe.Ingredients)
            .Include(foodRecipe => foodRecipe.IngredientWeights)
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        if (foodRecipe.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food recipe that you didn't create.");
        }
        
        var foodElementary = await dbContext.FoodElementaries
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        foodRecipe.Ingredients.Add(foodElementary);

        var elementaryWeight = new FoodElementaryWeight
        {
            FoodElementaryId = foodElementary.Id,
            FoodElementary = foodElementary,
            FoodRecipeId = foodRecipe.Id,
            FoodRecipe = foodRecipe,
            Weight = request.FoodElementaryWeight
        };
        dbContext.FoodElementaryWeights.Add(elementaryWeight);
        foodRecipe.IngredientWeights.Add(elementaryWeight);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
