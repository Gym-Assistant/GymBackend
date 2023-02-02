using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryDetailById;

/// <summary>
/// Get food elementary detail with information by id query handler.
/// </summary>
internal class GetFoodElementaryDetailByIdQueryHandler : IRequestHandler<GetFoodElementaryDetailByIdQuery, DetailFoodElementaryDto>
{
    private readonly IMapper mapper;
    private readonly IFoodDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodElementaryDetailByIdQueryHandler(IMapper mapper, IFoodDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<DetailFoodElementaryDto> Handle(GetFoodElementaryDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodElementaries
            .ProjectTo<DetailFoodElementaryDto>(mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        return food;
    }
}
