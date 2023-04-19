using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.DeleteCharacteristicStampById;

/// <summary>
/// Handler for <see cref="DeleteCharacteristicStampByIdCommand"/>.
/// </summary>
internal class DeleteCharacteristicStampByIdCommandHandler : BaseCommandHandler, IRequestHandler<DeleteCharacteristicStampByIdCommand>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteCharacteristicStampByIdCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task Handle(DeleteCharacteristicStampByIdCommand request, CancellationToken cancellationToken)
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
    }
}
