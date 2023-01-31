using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristic;

/// <summary>
/// Create food characteristic type command handler.
/// </summary>
internal class CreateFoodCharacteristicCommandHandler : IRequestHandler<CreateFoodCharacteristicCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodCharacteristicCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateFoodCharacteristicCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodElementaries
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);
        var characteristicType = await dbContext.FoodCharacteristicTypes
            .GetAsync(type => type.Id == request.CharacteristicTypeId, cancellationToken);
        var foodCharacteristic = new Domain.Foodstuffs.FoodCharacteristic
        {
            FoodElementaryId = food.Id,
            FoodElementary = food,
            CharacteristicTypeId = characteristicType.Id,
            CharacteristicType = characteristicType,
            UserId = loggedUserAccessor.GetCurrentUserId(),
            Value = request.Value
        };

        dbContext.FoodCharacteristics.Add(foodCharacteristic);
        await dbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
