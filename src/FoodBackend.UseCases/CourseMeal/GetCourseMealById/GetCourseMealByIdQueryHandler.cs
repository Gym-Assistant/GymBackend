using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealById;

/// <summary>
/// Get food characteristic type query handler.
/// </summary>
internal class GetCourseMealByIdQueryHandler : 
    IRequestHandler<GetCourseMealByIdQuery, LightCourseMealDto>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCourseMealByIdQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task<LightCourseMealDto> Handle(GetCourseMealByIdQuery request, CancellationToken cancellationToken)
    {
        var courseMeal = await dbContext.CourseMeals
            .ProjectTo<LightCourseMealDto>(mapper.ConfigurationProvider)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId,
                cancellationToken);

        return courseMeal;
    }
}
