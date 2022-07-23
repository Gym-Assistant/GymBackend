using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.DeleteCharacteristicValuesById;

/// <summary>
/// Handler for <see cref="DeleteCharacteristicValuesByIdCommand"/>.
/// </summary>
public class DeleteCharacteristicValuesByIdCommandHandler : BaseCommandHandler, IRequestHandler<DeleteCharacteristicValuesByIdCommand, Unit>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteCharacteristicValuesByIdCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(DeleteCharacteristicValuesByIdCommand request, CancellationToken cancellationToken)
    {
        var characteristicStamp =
            await DbContext.CharacteristicStamps
                .Include(stamp => stamp.UserCharacteristic)
                .Where(stamp => stamp.UserCharacteristicId == request.CharacteristicId)
                .GetAsync(stamp => stamp.Id == request.CharacteristicStampId, cancellationToken);

        if (characteristicStamp.UserCharacteristic.UserId != request.UserId)
        {
            throw new ForbiddenException("You're not allowed to delete this characteristic value");
        }

        DbContext.CharacteristicStamps.Remove(characteristicStamp);
        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
