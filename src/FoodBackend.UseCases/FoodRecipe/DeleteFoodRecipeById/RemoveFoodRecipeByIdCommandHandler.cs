using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.DeleteFoodRecipeById;

/// <summary>
/// Remove food recipe by id command handler.
/// </summary>
internal class RemoveFoodRecipeByIdCommandHandler : IRequestHandler<RemoveFoodRecipeByIdCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodRecipeByIdCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodRecipeByIdCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodRecipes
            .GetAsync(food => food.Id == request.FoodRecipeId, cancellationToken);
        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove food recipe that you didn't create.");
        }
        
        dbContext.FoodRecipes.Remove(food);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
