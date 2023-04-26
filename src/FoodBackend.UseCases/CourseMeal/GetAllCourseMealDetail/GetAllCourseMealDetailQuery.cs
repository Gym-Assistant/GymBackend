using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMealDetail;

/// <summary>
/// Get all course meal detail query.
/// </summary>
public record GetAllCourseMealDetailQuery : PageQueryFilter, IRequest<PagedListMetadataDto<DetailCourseMealDto>>;
