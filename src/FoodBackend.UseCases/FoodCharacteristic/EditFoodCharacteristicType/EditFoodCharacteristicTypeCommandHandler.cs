using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristicType;

/// <summary>
/// Edit food characteristic type handler.
/// </summary>
internal class EditFoodCharacteristicTypeCommandHandler : IRequestHandler<EditFoodCharacteristicTypeCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodCharacteristicTypeCommandHandler(ILoggedUserAccessor loggedUserAccessor, IFoodDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodCharacteristicTypeCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = await dbContext.FoodCharacteristicTypes.GetAsync(
            foodCharacteristicType => foodCharacteristicType.Id == request.FoodCharacteristicTypeId, cancellationToken);

        if (foodCharacteristicType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food characteristic type that you didn't create.");
        }
        
        if (request.Name != null)
        {
            foodCharacteristicType.Name = request.Name;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
