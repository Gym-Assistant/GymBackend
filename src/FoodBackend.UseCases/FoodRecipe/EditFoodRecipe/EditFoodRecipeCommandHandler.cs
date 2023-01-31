using AutoMapper;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.EditFoodRecipe;

/// <summary>
/// Edit food recipe command handler.
/// </summary>
internal class EditFoodRecipeCommandHandler : IRequestHandler<EditFoodRecipeCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodRecipeCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodRecipes
            .GetAsync(food => food.Id == request.Id, cancellationToken);
        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food recipe that you didn't create.");
        }

        if (request.Name != null)
        {
            food.Name = request.Name;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
