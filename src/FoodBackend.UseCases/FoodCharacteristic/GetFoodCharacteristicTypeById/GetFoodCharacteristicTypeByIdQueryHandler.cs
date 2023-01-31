using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicTypeById;

/// <summary>
/// Get food characteristic type query handler.
/// </summary>
internal class GetFoodCharacteristicTypeByIdQueryHandler : 
    IRequestHandler<GetFoodCharacteristicTypeByIdQuery, LightFoodCharacteristicTypeDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodCharacteristicTypeByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task<LightFoodCharacteristicTypeDto> Handle(GetFoodCharacteristicTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var foodCharacteristicType = await dbContext.FoodCharacteristicTypes
            .ProjectTo<LightFoodCharacteristicTypeDto>(mapper.ConfigurationProvider)
            .GetAsync(foodCharacteristicType => foodCharacteristicType.Id == request.FoodCharacteristicTypeId,
                cancellationToken);

        return foodCharacteristicType;
    }
}
