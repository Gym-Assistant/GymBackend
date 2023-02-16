using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicById;

/// <summary>
/// Remove food characteristic by id command handler.
/// </summary>
internal class RemoveFoodCharacteristicByIdCommandHandler : BaseCommandHandler,
    IRequestHandler<RemoveFoodCharacteristicByIdCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodCharacteristicByIdCommandHandler(IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodCharacteristicByIdCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristic = await DbContext.FoodCharacteristics
            .GetAsync(foodCharacteristic => foodCharacteristic.Id == request.FoodCharacteristicId,
                cancellationToken);

        if (foodCharacteristic.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove food characteristic that you didn't create.");
        }
        
        DbContext.FoodCharacteristics.Remove(foodCharacteristic);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
