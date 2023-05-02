using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicTypeById;

/// <summary>
/// Get food characteristic type query handler.
/// </summary>
internal class GetFoodCharacteristicTypeByIdQueryHandler : BaseQueryHandler, 
    IRequestHandler<GetFoodCharacteristicTypeByIdQuery, FoodCharacteristicTypeDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodCharacteristicTypeByIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }
    
    /// <inheritdoc />
    public async Task<FoodCharacteristicTypeDto> Handle(GetFoodCharacteristicTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = await DbContext.FoodCharacteristicTypes
            .ProjectTo<FoodCharacteristicTypeDto>(Mapper.ConfigurationProvider)
            .GetAsync(foodCharacteristicType => foodCharacteristicType.Id == request.FoodCharacteristicTypeId,
                cancellationToken);

        return foodCharacteristicType;
    }
}
