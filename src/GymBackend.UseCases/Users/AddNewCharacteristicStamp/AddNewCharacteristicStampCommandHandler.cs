using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.AddNewCharacteristicStamp;

/// <summary>
/// Handler for <see cref="AddNewCharacteristicStampCommand"/>.
/// </summary>
internal class AddNewCharacteristicStampCommandHandler : BaseCommandHandler, IRequestHandler<AddNewCharacteristicStampCommand, Guid>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AddNewCharacteristicStampCommandHandler(IMapper mapper, IAppDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(AddNewCharacteristicStampCommand request, CancellationToken cancellationToken)
    {
        var characteristic = await DbContext.UserCharacteristics
            .GetAsync(userCharacteristic => userCharacteristic.Id == request.CharacteristicId, cancellationToken);
        if (characteristic.UserId != request.UserId)
        {
            throw new ForbiddenException("User does not own this characteristic");
        }
        var newValue = new CharacteristicStamp()
        {
            UserCharacteristicId = request.CharacteristicId,
            Value = request.Value,
            CreatedAt = DateTime.UtcNow
        };
        DbContext.CharacteristicStamps.Add(newValue);
        await DbContext.SaveChangesAsync(cancellationToken);

        return newValue.Id;
    }
}
