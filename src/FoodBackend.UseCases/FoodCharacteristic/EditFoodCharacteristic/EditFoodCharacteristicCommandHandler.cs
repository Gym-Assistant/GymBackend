using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristic;

/// <summary>
/// Edit food characteristic handler.
/// </summary>
internal class EditFoodCharacteristicCommandHandler : BaseCommandHandler, IRequestHandler<EditFoodCharacteristicCommand, Unit>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodCharacteristicCommandHandler(IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodCharacteristicCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristic = await DbContext.FoodCharacteristics
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

        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
