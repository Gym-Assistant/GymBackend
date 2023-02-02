﻿using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipe;

/// <summary>
/// Get all food recipes query.
/// </summary>
public record GetAllFoodRecipesQuery : PaginationParameters, IRequest<PagedListMetadataDto<LightFoodRecipeDto>>;