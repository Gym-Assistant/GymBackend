using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.AddRecipeToCourseMeal;

/// <summary>
/// Add recipe to course meal command handler.
/// </summary>
internal class AddRecipeToCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<AddRecipeToCourseMealCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddRecipeToCourseMealCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<Unit> Handle(AddRecipeToCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodRecipes)
            .Include(courseMeal => courseMeal.ConsumedRecipeWeights)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that not belong to you.");
        }
        
        var foodRecipe = await DbContext.FoodRecipes
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        courseMeal.ConsumedFoodRecipes.Add(foodRecipe);
        var consumedRecipeWeight = Mapper.Map<ConsumedRecipeWeight>(request);
        consumedRecipeWeight.UserId = loggedUserAccessor.GetCurrentUserId();
        await DbContext.ConsumedRecipeWeights.AddAsync(consumedRecipeWeight, cancellationToken);
        courseMeal.ConsumedRecipeWeights.Add(consumedRecipeWeight);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
