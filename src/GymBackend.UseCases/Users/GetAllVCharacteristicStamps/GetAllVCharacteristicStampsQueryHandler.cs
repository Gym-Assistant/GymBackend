using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.User;
using MediatR;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.GetAllVCharacteristicStamps;

/// <summary>
/// Handler for <see cref="GetAllCharacteristicStampsQuery"/>.
/// </summary>
internal class GetAllVCharacteristicStampsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllCharacteristicStampsQuery, IEnumerable<CharacteristicStampDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllVCharacteristicStampsQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CharacteristicStampDto>> Handle(GetAllCharacteristicStampsQuery request, CancellationToken cancellationToken)
    {
        var userCharacteristicDto = await DbContext.UserCharacteristics.ProjectTo<UserCharacteristicDto>(Mapper.ConfigurationProvider)
            .GetAsync(dto => dto.IsActive == true && dto.Id == request.CharacteristicId, cancellationToken);

        return userCharacteristicDto.Values;
    }
}
