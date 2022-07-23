﻿using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.AddDefaultCharacteristicForUser;

/// <summary>
/// Handler for <see cref="AddDefaultCharacteristicForUserCommand"/>.
/// </summary>
public class AddDefaultCharacteristicForUserCommandHandler : BaseCommandHandler, IRequestHandler<AddDefaultCharacteristicForUserCommand, Unit>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AddDefaultCharacteristicForUserCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(AddDefaultCharacteristicForUserCommand request, CancellationToken cancellationToken)
    {
        var user = await DbContext.Users.GetAsync(user => user.Id == request.UserId, cancellationToken);
        var defaultCharacteristics = DefaultCharacteristics.GetAll().Select(name => new UserCharacteristic()
        {
            Name = name,
            UserId = user.Id,
            IsActive = false,
            CreatedAt = DateTime.UtcNow
        }).ToList();
        DbContext.UserCharacteristics.AddRange(defaultCharacteristics);

        await DbContext.SaveChangesAsync(CancellationToken.None);
        return Unit.Value;
    }
}
