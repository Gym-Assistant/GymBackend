using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Domain.Users;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.User;
using MediatR;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Users.GetAllValuesForCharacteristic;

/// <summary>
/// Handler for <see cref="GetAllValuesForCharacteristicQuery"/>.
/// </summary>
public class GetAllValuesForCharacteristicQueryHandler : BaseQueryHandler, IRequestHandler<GetAllValuesForCharacteristicQuery, IEnumerable<CharacteristicStampDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllValuesForCharacteristicQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CharacteristicStampDto>> Handle(GetAllValuesForCharacteristicQuery request, CancellationToken cancellationToken)
    {
        var userCharacteristicDto = await DbContext.UserCharacteristics.ProjectTo<UserCharacteristicDto>(Mapper.ConfigurationProvider)
            .GetAsync(dto => dto.IsActive == true && dto.Id == request.CharacteristicId, cancellationToken);

        return userCharacteristicDto.Values;
    }
}
