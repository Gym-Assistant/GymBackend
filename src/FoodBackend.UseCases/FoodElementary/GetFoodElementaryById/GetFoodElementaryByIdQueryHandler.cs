﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryById;

/// <summary>
/// Get food elementary detail with information by id query handler.
/// </summary>
internal class GetFoodElementaryByIdQueryHandler : BaseQueryHandler,
    IRequestHandler<GetFoodElementaryByIdQuery, DetailFoodElementaryDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodElementaryByIdQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc/>
    public async Task<DetailFoodElementaryDto> Handle(GetFoodElementaryByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodElementaries
            .ProjectTo<DetailFoodElementaryDto>(Mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        return food;
    }
}
