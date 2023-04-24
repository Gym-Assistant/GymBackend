using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.RemoveRecipeFromCourseMeal;

/// <summary>
/// Remove recipe from course meal command handler.
/// </summary>
internal class RemoveRecipeFromCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<RemoveRecipeFromCourseMealCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveRecipeFromCourseMealCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task Handle(RemoveRecipeFromCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodRecipes)
            .Include(courseMeal => courseMeal.ConsumedRecipeWeights)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that you didn't create.");
        }
        
        var foodRecipe = await DbContext.FoodRecipes
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        courseMeal.ConsumedFoodRecipes.Remove(foodRecipe);
        var recipeWeight = await DbContext.ConsumedRecipeWeights
            .GetAsync(foodRecipeWeight => foodRecipeWeight.FoodRecipeId == request.FoodRecipeId &&
                                          foodRecipeWeight.CourseMealId == request.CourseMealId, cancellationToken);
        DbContext.ConsumedRecipeWeights.Remove(recipeWeight);
        courseMeal.ConsumedRecipeWeights.Remove(recipeWeight);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
