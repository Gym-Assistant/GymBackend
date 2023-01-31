using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeById;

/// <summary>
/// Get food recipe by id query handler.
/// </summary>
internal class GetFoodRecipeByIdQueryHandler : IRequestHandler<GetFoodRecipeByIdQuery, LightFoodRecipeDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodRecipeByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<LightFoodRecipeDto> Handle(GetFoodRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodRecipes
            .ProjectTo<LightFoodRecipeDto>(mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodRecipeId, cancellationToken);

        return food;
    }
}
