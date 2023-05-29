using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.AddIngredientToRecipe;

/// <summary>
/// Add ingredient to recipe command handler.
/// </summary>
internal class AddIngredientToRecipeCommandHandler : BaseCommandHandler, IRequestHandler<AddIngredientToRecipeCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddIngredientToRecipeCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task Handle(AddIngredientToRecipeCommand request, CancellationToken cancellationToken)
    {
        const bool increaseCharacteristicSumStatement = true;
        var foodRecipe = await DbContext.FoodRecipes
            .Include(foodRecipe => foodRecipe.Ingredients)
            .Include(foodRecipe => foodRecipe.IngredientWeights)
            .Include(foodRecipe => foodRecipe.CharacteristicValuesSum)
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        if (foodRecipe.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food recipe that you didn't create.");
        }
        var foodElementary = await DbContext.FoodElementaries
            .Include(elementary => elementary.Characteristics)
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        foodRecipe.Ingredients.Add(foodElementary);
        var elementaryWeight = Mapper.Map<FoodElementaryWeight>(request);
        await DbContext.FoodElementaryWeights.AddAsync(elementaryWeight, cancellationToken);
        foodRecipe.IngredientWeights.Add(elementaryWeight);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
