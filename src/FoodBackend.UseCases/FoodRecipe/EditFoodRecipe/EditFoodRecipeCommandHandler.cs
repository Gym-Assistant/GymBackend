using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.EditFoodRecipe;

/// <summary>
/// Edit food recipe command handler.
/// </summary>
internal class EditFoodRecipeCommandHandler : BaseCommandHandler, IRequestHandler<EditFoodRecipeCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodRecipeCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodRecipes
            .GetAsync(food => food.Id == request.Id, cancellationToken);
        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food recipe that you didn't create.");
        }

        if (request.Name != null)
        {
            food.Name = request.Name;
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
