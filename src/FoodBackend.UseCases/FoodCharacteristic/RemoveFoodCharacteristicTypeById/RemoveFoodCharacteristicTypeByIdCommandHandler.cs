using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicTypeById;

/// <summary>
/// Remove food characteristic type by id command handler.
/// </summary>
internal class RemoveFoodCharacteristicTypeByIdCommandHandler : IRequestHandler<RemoveFoodCharacteristicTypeByIdCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodCharacteristicTypeByIdCommandHandler(IFoodDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodCharacteristicTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = await dbContext.FoodCharacteristicTypes
            .GetAsync(foodCharacteristicType => foodCharacteristicType.Id == request.FoodCharacteristicTypeId,
                cancellationToken);
        if (foodCharacteristicType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove food characteristic type that you didn't create.");
        }

        dbContext.FoodCharacteristicTypes.Remove(foodCharacteristicType);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
