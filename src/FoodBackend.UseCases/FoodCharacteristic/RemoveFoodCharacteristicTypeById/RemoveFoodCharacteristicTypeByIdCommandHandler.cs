using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicTypeById;

/// <summary>
/// Remove food characteristic type by id command handler.
/// </summary>
internal class RemoveFoodCharacteristicTypeByIdCommandHandler : BaseCommandHandler,
    IRequestHandler<RemoveFoodCharacteristicTypeByIdCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodCharacteristicTypeByIdCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task Handle(RemoveFoodCharacteristicTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = await DbContext.FoodCharacteristicTypes
            .GetAsync(foodCharacteristicType => foodCharacteristicType.Id == request.FoodCharacteristicTypeId,
                cancellationToken);
        if (foodCharacteristicType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove food characteristic type that you didn't create.");
        }

        DbContext.FoodCharacteristicTypes.Remove(foodCharacteristicType);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
