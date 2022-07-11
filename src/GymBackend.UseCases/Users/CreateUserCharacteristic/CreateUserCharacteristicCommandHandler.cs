using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;

namespace GymBackend.UseCases.Users.CreateUserCharacteristic;

/// <summary>
/// Handler for <see cref="CreateUserCharacteristicCommand"/>.
/// </summary>
public class CreateUserCharacteristicCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateUserCharacteristicCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateUserCharacteristicCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor) 
        : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateUserCharacteristicCommand request, CancellationToken cancellationToken)
    {
        if (loggedUserAccessor.GetCurrentUserId() != request.UserId)
        {
            throw new ForbiddenException("You have no rights to create user characteristic");
        }

        var userCharacteristic = new UserCharacteristic()
        {
            Name = request.Name,
            UserId = request.UserId,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        DbContext.UserCharacteristics.Add(userCharacteristic);
        await DbContext.SaveChangesAsync(cancellationToken);

        return userCharacteristic.Id;
    }
}