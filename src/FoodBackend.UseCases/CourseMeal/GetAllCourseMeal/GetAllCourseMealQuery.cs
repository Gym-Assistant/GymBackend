using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMeal;

/// <summary>
/// Get all course meal query.
/// </summary>
public record GetAllCourseMealQuery : 
    PaginationParameters, IRequest<PagedListMetadataDto<LightCourseMealDto>>;
