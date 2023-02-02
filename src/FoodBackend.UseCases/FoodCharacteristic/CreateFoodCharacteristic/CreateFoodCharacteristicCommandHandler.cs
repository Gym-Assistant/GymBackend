using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
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
        var foodElementary = await dbContext.FoodElementaries
            .Include(foodElementary => foodElementary.Characteristics)
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        if (foodElementary.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food elementary that you didn't create.");
        }
        
        var characteristicType = await dbContext.FoodCharacteristicTypes
            .GetAsync(type => type.Id == request.CharacteristicTypeId, cancellationToken);
        var foodCharacteristic = new Domain.Foodstuffs.FoodCharacteristic
        {
            FoodElementaryId = foodElementary.Id,
            FoodElementary = foodElementary,
            CharacteristicTypeId = characteristicType.Id,
            CharacteristicType = characteristicType,
            UserId = loggedUserAccessor.GetCurrentUserId(),
            Value = request.Value
        };
        
        foodElementary.Characteristics.Add(foodCharacteristic);

        dbContext.FoodCharacteristics.Add(foodCharacteristic);
        await dbContext.SaveChangesAsync(cancellationToken);

        return foodCharacteristic.Id;
    }
}
