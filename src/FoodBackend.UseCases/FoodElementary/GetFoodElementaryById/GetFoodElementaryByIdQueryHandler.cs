using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryById;

/// <summary>
/// Get food elementary by id query handler.
/// </summary>
internal class GetFoodElementaryByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetFoodElementaryByIdQuery, LightFoodElementaryDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodElementaryByIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }
    
    /// <inheritdoc />
    public async Task<LightFoodElementaryDto> Handle(GetFoodElementaryByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodElementaries
            .ProjectTo<LightFoodElementaryDto>(Mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        return food;
    }
}
