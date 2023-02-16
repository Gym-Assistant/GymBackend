using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.MealType.GetMealTypeById;

/// <summary>
/// Get meal type query handler.
/// </summary>
internal class GetMealTypeByIdQueryHandler : BaseQueryHandler,
    IRequestHandler<GetMealTypeByIdQuery, LightMealTypeDto>
{

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetMealTypeByIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }
    
    /// <inheritdoc />
    public async Task<LightMealTypeDto> Handle(GetMealTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var mealType = await DbContext.MealTypes
            .ProjectTo<LightMealTypeDto>(Mapper.ConfigurationProvider)
            .GetAsync(mealType => mealType.Id == request.MealTypeId,
                cancellationToken);

        return mealType;
    }
}
