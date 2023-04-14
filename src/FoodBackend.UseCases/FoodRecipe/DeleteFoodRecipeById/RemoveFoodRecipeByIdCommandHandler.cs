using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.DeleteFoodRecipeById;

/// <summary>
/// Remove food recipe by id command handler.
/// </summary>
internal class RemoveFoodRecipeByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveFoodRecipeByIdCommand, Unit>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodRecipeByIdCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodRecipeByIdCommand request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodRecipes
            .GetAsync(food => food.Id == request.FoodRecipeId, cancellationToken);
        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove food recipe that you didn't create.");
        }
        
        DbContext.FoodRecipes.Remove(food);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
