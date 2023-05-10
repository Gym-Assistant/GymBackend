using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.CreateFoodElementary;

/// <summary>
/// Crete food elementary command handler.
/// </summary>
internal class CreateFoodElementaryCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateFoodElementaryCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodElementaryCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodElementaryCommand request, CancellationToken cancellationToken)
    {
        var food = Mapper.Map<Domain.Foodstuffs.FoodElementary>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        await DbContext.FoodElementaries.AddAsync(food, cancellationToken);
        if (request.ProteinValue != null)
        {
            var proteinCharacteristicType = await DbContext.FoodCharacteristicTypes
                .GetAsync(type => type.Id == FoodCharacteristicDefaults.ProteinId, cancellationToken);
            var proteinCharacteristic = new Domain.Foodstuffs.FoodCharacteristic
            {
                CharacteristicType = proteinCharacteristicType,
                CharacteristicTypeId = proteinCharacteristicType.Id,
                FoodElementary = food,
                FoodElementaryId = food.Id,
                //TODO: Fix type in migration
                IsDefault = 1,
                Value = request.ProteinValue.Value
            };
            await DbContext.FoodCharacteristics.AddAsync(proteinCharacteristic, cancellationToken);
            food.Characteristics.Add(proteinCharacteristic);
        }
        await DbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
