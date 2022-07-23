using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.UseCases.Users.GetAllUserCharacteristicByUserId;

/// <summary>
/// Handler for <see cref="GetAllUserCharacteristicByUserIdQuery"/>.
/// </summary>
internal class GetAllUserCharacteristicByUserIdQueryHandler : BaseQueryHandler, IRequestHandler<GetAllUserCharacteristicByUserIdQuery, IEnumerable<UserCharacteristicLiteDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllUserCharacteristicByUserIdQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IEnumerable<UserCharacteristicLiteDto>> Handle(GetAllUserCharacteristicByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userCharacteristicsDtos = await Mapper.ProjectTo<UserCharacteristicLiteDto>(DbContext.UserCharacteristics
            .Where(characteristic => characteristic.UserId == request.UserId)).ToListAsync(cancellationToken);

        return userCharacteristicsDtos;
    }
}
