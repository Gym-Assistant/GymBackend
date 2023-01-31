using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicById;

/// <summary>
/// Remove food characteristic by id command handler.
/// </summary>
internal class RemoveFoodCharacteristicByIdCommandHandler : IRequestHandler<RemoveFoodCharacteristicByIdCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodCharacteristicByIdCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodCharacteristicByIdCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristic = await dbContext.FoodCharacteristics
            .GetAsync(foodCharacteristic => foodCharacteristic.Id == request.FoodCharacteristicId,
                cancellationToken);

        if (foodCharacteristic.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove food characteristic that you didn't create.");
        }
        
        dbContext.FoodCharacteristics.Remove(foodCharacteristic);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
