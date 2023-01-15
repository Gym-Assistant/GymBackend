using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.Food.GetFoodById;

/// <summary>
/// Get food by id query handler.
/// </summary>
internal class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, LightFoodDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<LightFoodDto> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await dbContext.Foods
            .ProjectTo<LightFoodDto>(mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodId, cancellationToken);

        return food;
    }
}
