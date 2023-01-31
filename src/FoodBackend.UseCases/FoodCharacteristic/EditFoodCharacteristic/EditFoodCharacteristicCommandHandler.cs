using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristic;

/// <summary>
/// Edit food characteristic handler.
/// </summary>
internal class EditFoodCharacteristicCommandHandler : IRequestHandler<EditFoodCharacteristicCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodCharacteristicCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodCharacteristicCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristic = await dbContext.FoodCharacteristics
            .GetAsync(foodCharacteristic => foodCharacteristic.Id == request.FoodCharacteristicId,
                cancellationToken);
        
        if (foodCharacteristic.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food characteristic type that you didn't create.");
        }
        
        if (request.Value != null)
        {
            foodCharacteristic.Value = request.Value;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
