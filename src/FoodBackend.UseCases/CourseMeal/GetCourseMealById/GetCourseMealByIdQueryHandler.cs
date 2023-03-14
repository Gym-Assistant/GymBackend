﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealById;

/// <summary>
/// Get food characteristic type query handler.
/// </summary>
internal class GetCourseMealByIdQueryHandler : 
    BaseQueryHandler, IRequestHandler<GetCourseMealByIdQuery, LightCourseMealDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCourseMealByIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }
    
    /// <inheritdoc />
    public async Task<LightCourseMealDto> Handle(GetCourseMealByIdQuery request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .ProjectTo<LightCourseMealDto>(Mapper.ConfigurationProvider)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId,
                cancellationToken);

        return courseMeal;
    }
}
