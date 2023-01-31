using AutoMapper;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.CreateFoodRecipe;

/// <summary>
/// Create food recipe command handler.
/// </summary>
internal class CreateFoodRecipeCommandHandler : IRequestHandler<CreateFoodRecipeCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodRecipeCommandHandler(IFoodDbContext dbContext, IMapper mapper, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        var food = mapper.Map<Domain.Foodstuffs.FoodRecipe>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        dbContext.FoodRecipes.Add(food);
        await dbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
