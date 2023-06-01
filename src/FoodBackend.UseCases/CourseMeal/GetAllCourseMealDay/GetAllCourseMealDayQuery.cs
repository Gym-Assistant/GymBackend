using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMealDay;

/// <summary>
/// Get all course meal day query.
/// </summary>
public record GetAllCourseMealDayQuery(DateOnly? CourseMealDayDate) : PageQueryFilter, IRequest<PagedListMetadataDto<LightCourseMealDayDto>>;
