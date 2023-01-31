using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicById;

/// <summary>
/// Get food characteristic query handler.
/// </summary>
internal class GetFoodCharacteristicByIdQueryHandler : 
    IRequestHandler<GetFoodCharacteristicByIdQuery, LightFoodCharacteristicDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodCharacteristicByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task<LightFoodCharacteristicDto> Handle(GetFoodCharacteristicByIdQuery request, CancellationToken cancellationToken)
    {
        var foodCharacteristic = await dbContext.FoodCharacteristics
            .ProjectTo<LightFoodCharacteristicDto>(mapper.ConfigurationProvider)
            .GetAsync(foodCharacteristic => foodCharacteristic.Id == request.FoodCharacteristicId,
                cancellationToken);

        return foodCharacteristic;
    }
}
