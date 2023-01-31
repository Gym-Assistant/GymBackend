using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.MealType.GetMealTypeById;

/// <summary>
/// Get meal type query handler.
/// </summary>
internal class GetMealTypeByIdQueryHandler : 
    IRequestHandler<GetMealTypeByIdQuery, LightMealTypeDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetMealTypeByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task<LightMealTypeDto> Handle(GetMealTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var mealType = await dbContext.MealTypes
            .ProjectTo<LightMealTypeDto>(mapper.ConfigurationProvider)
            .GetAsync(mealType => mealType.Id == request.MealTypeId,
                cancellationToken);

        return mealType;
    }
}
