using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristic;

/// <summary>
/// Create food characteristic type command handler.
/// </summary>
internal class CreateFoodCharacteristicCommandHandler : BaseCommandHandler, IRequestHandler<CreateFoodCharacteristicCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodCharacteristicCommandHandler(IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateFoodCharacteristicCommand request, CancellationToken cancellationToken)
    {
        var foodElementary = await DbContext.FoodElementaries
            .Include(foodElementary => foodElementary.Characteristics)
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        if (foodElementary.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food elementary that you didn't create.");
        }
        
        var characteristicType = await DbContext.FoodCharacteristicTypes
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

        await DbContext.FoodCharacteristics.AddAsync(foodCharacteristic, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return foodCharacteristic.Id;
    }
}
