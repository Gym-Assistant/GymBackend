using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.ChangeRecipeWeightInCourseMeal;

/// <summary>
/// Change recipe weight in course meal command handler.
/// </summary>
internal class ChangeRecipeWeightInCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<ChangeRecipeWeightInCourseMealCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public ChangeRecipeWeightInCourseMealCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task Handle(ChangeRecipeWeightInCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodRecipes)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that you didn't create.");
        }
        
        var foodRecipe = await DbContext.FoodRecipes
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        if (!courseMeal.ConsumedFoodRecipes.Contains(foodRecipe))
        {
            throw new NotFoundException("There is no such food recipe in current course meal.");
        }
        var recipeWeight = await DbContext.ConsumedRecipeWeights
            .GetAsync(foodRecipeWeight => foodRecipeWeight.FoodRecipeId == request.FoodRecipeId &&
                                              foodRecipeWeight.CourseMealId == request.CourseMealId, cancellationToken);
        recipeWeight.Weight = request.Weight;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
