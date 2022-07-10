using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.UpdateUserProfile;

/// <summary>
/// Handler for <see cref="UpdateUserProfileCommand"/>.
/// </summary>
internal class UpdateUserProfileCommandHandler : BaseCommandHandler, IRequestHandler<UpdateUserProfileCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateUserProfileCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request.Id != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You haven't permission for modify this user.");
        }
        var user = await DbContext.Users.GetAsync(user => user.Id == request.Id, cancellationToken);
        if (request.FirstName is not null)
        {
            user.FirstName = request.FirstName;
        }

        if (request.LastName is not null)
        {
            user.LastName = request.LastName;
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
