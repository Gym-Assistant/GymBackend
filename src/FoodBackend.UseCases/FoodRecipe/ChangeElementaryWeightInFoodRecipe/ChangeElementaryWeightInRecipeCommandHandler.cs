using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.ChangeElementaryWeightInFoodRecipe;

/// <summary>
/// Change food elementary weight in food recipe command handler.
/// </summary>
internal class ChangeElementaryWeightInRecipeCommandHandler : BaseCommandHandler, IRequestHandler<ChangeElementaryWeightInRecipeCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IChangeRecipeCharacteristicSum changeRecipeCharacteristicSum;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ChangeElementaryWeightInRecipeCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IChangeRecipeCharacteristicSum changeRecipeCharacteristicSum) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.changeRecipeCharacteristicSum = changeRecipeCharacteristicSum;
    }

    /// <inheritdoc/>
    public async Task Handle(ChangeElementaryWeightInRecipeCommand request, CancellationToken cancellationToken)
    {
        const bool increaseCharacteristicSumStatement = true;
        const bool decreaseCharacteristicSumStatement = false;
        var foodRecipe = await DbContext.FoodRecipes
            .Include(recipe =>  recipe.Ingredients)
            .Include(recipe => recipe.IngredientWeights)
            .Include(recipe => recipe.CharacteristicValuesSum)
            .GetAsync(recipe => recipe.Id == request.FoodRecipeId, cancellationToken);
        if (foodRecipe.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food recipe that you didn't create.");
        }
        
        var foodElementary = await DbContext.FoodElementaries
            .Include(elementary => elementary.Characteristics)
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        if (!foodRecipe.Ingredients.Contains(foodElementary))
        {
            throw new NotFoundException("There is no such food elementary in current food recipe.");
        }
        var elementaryWeight = await DbContext.FoodElementaryWeights
            .GetAsync(foodElementaryWeight => foodElementaryWeight.FoodElementaryId == request.FoodElementaryId &&
                                              foodElementaryWeight.FoodRecipeId == request.FoodRecipeId, cancellationToken);
        await changeRecipeCharacteristicSum.ChangeRecipeCharacteristic(foodRecipe, foodElementary, elementaryWeight.Weight,
            decreaseCharacteristicSumStatement, cancellationToken);
        elementaryWeight.Weight = request.Weight;
        await changeRecipeCharacteristicSum.ChangeRecipeCharacteristic(foodRecipe, foodElementary, request.Weight,
            increaseCharacteristicSumStatement, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
