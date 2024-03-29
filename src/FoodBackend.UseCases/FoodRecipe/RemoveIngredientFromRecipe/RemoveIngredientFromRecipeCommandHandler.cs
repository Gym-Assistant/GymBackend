﻿using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.RemoveIngredientFromRecipe;

/// <summary>
/// Remove ingredient from recipe command handler.
/// </summary>
internal class RemoveIngredientFromRecipeCommandHandler : BaseCommandHandler, IRequestHandler<RemoveIngredientFromRecipeCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveIngredientFromRecipeCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task Handle(RemoveIngredientFromRecipeCommand request, CancellationToken cancellationToken)
    {
        var foodRecipe = await DbContext.FoodRecipes
            .Include(foodRecipe => foodRecipe.Ingredients)
            .Include(foodRecipe => foodRecipe.IngredientWeights)
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        if (foodRecipe.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food recipe that you didn't create.");
        }
        
        var foodElementary = await DbContext.FoodElementaries
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        foodRecipe.Ingredients.Remove(foodElementary);
        var elementaryWeight = await DbContext.FoodElementaryWeights
            .GetAsync(foodElementaryWeight => foodElementaryWeight.FoodElementaryId == request.FoodElementaryId &&
                                              foodElementaryWeight.FoodRecipeId == request.FoodRecipeId, cancellationToken);
        DbContext.FoodElementaryWeights.Remove(elementaryWeight);
        foodRecipe.IngredientWeights.Remove(elementaryWeight);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
