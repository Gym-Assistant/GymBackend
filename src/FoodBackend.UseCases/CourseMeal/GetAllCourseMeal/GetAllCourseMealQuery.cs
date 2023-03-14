using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMeal;

/// <summary>
/// Get all course meal query.
/// </summary>
public record GetAllCourseMealQuery : 
    PageQueryFilter, IRequest<PagedListMetadataDto<LightCourseMealDto>>;
