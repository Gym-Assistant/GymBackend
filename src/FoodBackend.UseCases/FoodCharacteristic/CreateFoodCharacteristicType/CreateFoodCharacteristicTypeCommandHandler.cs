using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristicType;

/// <summary>
/// Create food characteristic type command handler.
/// </summary>
internal class CreateFoodCharacteristicTypeCommandHandler : BaseCommandHandler, IRequestHandler<CreateFoodCharacteristicTypeCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodCharacteristicTypeCommandHandler(IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateFoodCharacteristicTypeCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = Mapper.Map<FoodCharacteristicType>(request);
        foodCharacteristicType.UserId = loggedUserAccessor.GetCurrentUserId();
        await DbContext.FoodCharacteristicTypes.AddAsync(foodCharacteristicType, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return foodCharacteristicType.Id;
    }
}
