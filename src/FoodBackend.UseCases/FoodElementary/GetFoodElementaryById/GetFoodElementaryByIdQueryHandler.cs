using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryById;

/// <summary>
/// Get food elementary by id query handler.
/// </summary>
internal class GetFoodElementaryByIdQueryHandler : IRequestHandler<GetFoodElementaryByIdQuery, LightFoodElementaryDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodElementaryByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<LightFoodElementaryDto> Handle(GetFoodElementaryByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodElementaries
            .ProjectTo<LightFoodElementaryDto>(mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        return food;
    }
}
