using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
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
    private readonly IAddFoodRecipeCharacteristic recipeCharacteristic;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodRecipeCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor, IAddFoodRecipeCharacteristic recipeCharacteristic) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.recipeCharacteristic = recipeCharacteristic;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        var food = Mapper.Map<Domain.Foodstuffs.FoodRecipe>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        await recipeCharacteristic.AddRecipeCharacteristic(FoodCharacteristicDefaults.ProteinId, food, default(double), cancellationToken);
        await recipeCharacteristic.AddRecipeCharacteristic(FoodCharacteristicDefaults.FatId, food, default(double), cancellationToken);
        await recipeCharacteristic.AddRecipeCharacteristic(FoodCharacteristicDefaults.CarbohydrateId, food, default(double), cancellationToken);
        await recipeCharacteristic.AddRecipeCharacteristic(FoodCharacteristicDefaults.CaloriesId, food, default(double), cancellationToken);
        await DbContext.FoodRecipes.AddAsync(food, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
