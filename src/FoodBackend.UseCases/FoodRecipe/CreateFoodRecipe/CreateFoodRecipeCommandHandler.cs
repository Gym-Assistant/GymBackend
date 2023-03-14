using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.CreateFoodRecipe;

/// <summary>
/// Create food recipe command handler.
/// </summary>
internal class CreateFoodRecipeCommandHandler : BaseCommandHandler, IRequestHandler<CreateFoodRecipeCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodRecipeCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        var food = Mapper.Map<Domain.Foodstuffs.FoodRecipe>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        await DbContext.FoodRecipes.AddAsync(food, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
