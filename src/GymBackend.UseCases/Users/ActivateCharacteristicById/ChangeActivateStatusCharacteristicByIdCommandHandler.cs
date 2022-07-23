using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.ActivateCharacteristicById;

/// <summary>
/// Handler for <see cref="ChangeActivateStatusCharacteristicByIdCommand"/>.
/// </summary>
internal class ChangeActivateStatusCharacteristicByIdCommandHandler : BaseCommandHandler, IRequestHandler<ChangeActivateStatusCharacteristicByIdCommand, Unit>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ChangeActivateStatusCharacteristicByIdCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(ChangeActivateStatusCharacteristicByIdCommand request, CancellationToken cancellationToken)
    {
        var characteristic =
            await DbContext.UserCharacteristics
                .AsNoTracking()
                .GetAsync(userCharacteristic => userCharacteristic.Id == request.CharacteristicId, cancellationToken);

        if (characteristic.UserId != request.UserId)
        {
            throw new ForbiddenException("You can't change status of this characteristic");
        }

        characteristic = characteristic with
        {
            IsActive = !characteristic.IsActive
        };
        DbContext.UserCharacteristics.Update(characteristic);
        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
