using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristicType;

/// <summary>
/// Edit food characteristic type handler.
/// </summary>
internal class EditFoodCharacteristicTypeCommandHandler : BaseCommandHandler, IRequestHandler<EditFoodCharacteristicTypeCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodCharacteristicTypeCommandHandler(ILoggedUserAccessor loggedUserAccessor, IAppDbContext dbContext,
        IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task Handle(EditFoodCharacteristicTypeCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = await DbContext.FoodCharacteristicTypes.GetAsync(
            foodCharacteristicType => foodCharacteristicType.Id == request.FoodCharacteristicTypeId, cancellationToken);

        if (foodCharacteristicType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food characteristic type that you didn't create.");
        }
        
        if (request.Name != null)
        {
            foodCharacteristicType.Name = request.Name;
        }

        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
