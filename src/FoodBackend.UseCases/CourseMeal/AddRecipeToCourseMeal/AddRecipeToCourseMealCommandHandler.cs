using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.AddRecipeToCourseMeal;

/// <summary>
/// Add recipe to course meal command handler.
/// </summary>
internal class AddRecipeToCourseMealCommandHandler : IRequestHandler<AddRecipeToCourseMealCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddRecipeToCourseMealCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<Unit> Handle(AddRecipeToCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await dbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodRecipes)
            .Include(courseMeal => courseMeal.ConsumedRecipeWeights)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that not belong to you.");
        }
        
        var foodRecipe = await dbContext.FoodRecipes
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        courseMeal.ConsumedFoodRecipes.Add(foodRecipe);

        var consumedRecipeWeight = new ConsumedRecipeWeight
        {
            FoodRecipeId = foodRecipe.Id,
            FoodRecipe = foodRecipe,
            CourseMealId = courseMeal.Id,
            CourseMeal = courseMeal,
            Weight = request.Weight,
            UserId = loggedUserAccessor.GetCurrentUserId()
        };
        dbContext.ConsumedRecipeWeights.Add(consumedRecipeWeight);
        courseMeal.ConsumedRecipeWeights.Add(consumedRecipeWeight);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
