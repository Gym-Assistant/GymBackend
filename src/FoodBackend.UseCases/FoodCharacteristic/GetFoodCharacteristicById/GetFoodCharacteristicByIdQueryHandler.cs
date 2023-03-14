using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicById;

/// <summary>
/// Get food characteristic query handler.
/// </summary>
internal class GetFoodCharacteristicByIdQueryHandler : BaseQueryHandler,
    IRequestHandler<GetFoodCharacteristicByIdQuery, LightFoodCharacteristicDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodCharacteristicByIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }
    
    /// <inheritdoc />
    public async Task<LightFoodCharacteristicDto> Handle(GetFoodCharacteristicByIdQuery request, CancellationToken cancellationToken)
    {
        var foodCharacteristic = await DbContext.FoodCharacteristics
            .ProjectTo<LightFoodCharacteristicDto>(Mapper.ConfigurationProvider)
            .GetAsync(foodCharacteristic => foodCharacteristic.Id == request.FoodCharacteristicId,
                cancellationToken);

        return foodCharacteristic;
    }
}
