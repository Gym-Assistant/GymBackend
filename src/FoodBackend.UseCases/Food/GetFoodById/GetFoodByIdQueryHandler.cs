using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.Food.GetFoodById;

/// <summary>
/// Get food by id query handler.
/// </summary>
internal class GetFoodByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetFoodByIdQuery, LightFoodDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodByIdQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext) { }

    /// <inheritdoc/>
    public async Task<LightFoodDto> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await DbContext.Foods
                .ProjectTo<LightFoodDto>(Mapper.ConfigurationProvider)
                .GetAsync(food => food.Id == request.FoodId, cancellationToken);

        return food;
    }
}
