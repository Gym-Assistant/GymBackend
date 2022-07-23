using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.AddNewCharacteristicValue;

/// <summary>
/// Handler for <see cref="AddNewCharacteristicValueCommand"/>.
/// </summary>
internal class AddNewCharacteristicValueCommandHandler : BaseCommandHandler, IRequestHandler<AddNewCharacteristicValueCommand, Guid>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AddNewCharacteristicValueCommandHandler(IMapper mapper, IAppDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(AddNewCharacteristicValueCommand request, CancellationToken cancellationToken)
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
