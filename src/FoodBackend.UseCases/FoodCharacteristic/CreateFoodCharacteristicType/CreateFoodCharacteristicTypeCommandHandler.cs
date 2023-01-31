using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristicType;

/// <summary>
/// Create food characteristic type command handler.
/// </summary>
internal class CreateFoodCharacteristicTypeCommandHandler : IRequestHandler<CreateFoodCharacteristicTypeCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodCharacteristicTypeCommandHandler(IFoodDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateFoodCharacteristicTypeCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = mapper.Map<FoodCharacteristicType>(request);
        foodCharacteristicType.UserId = loggedUserAccessor.GetCurrentUserId();
        dbContext.FoodCharacteristicTypes.Add(foodCharacteristicType);
        await dbContext.SaveChangesAsync(cancellationToken);

        return foodCharacteristicType.Id;
    }
}
