using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.User;
using MediatR;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.GetUserProfileByUserId;

/// <summary>
/// Handler for <see cref="GetUserProfileByUserIdQuery"/>.
/// </summary>
internal class GetUserProfileByUserIdQueryHandler : BaseQueryHandler, IRequestHandler<GetUserProfileByUserIdQuery, UserProfileDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetUserProfileByUserIdQueryHandler(IMapper mapper, IAppDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public Task<UserProfileDto> Handle(GetUserProfileByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userProfileDto = Mapper.ProjectTo<UserProfileDto>(DbContext.Users)
            .GetAsync(user => user.Id == request.UserId, cancellationToken);

        return userProfileDto;
    }
}
