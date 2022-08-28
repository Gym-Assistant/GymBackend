using GymBackend.UseCases.Common.Dtos.Workout;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.UseCases.Exercise.GetAllExercises;

/// <summary>
/// Get all exercises for specific user.
/// </summary>
/// <param name="UserId">User id.</param>
public record GetAllExercisesQuery(Guid UserId) : PageQueryFilter, IRequest<PagedListMetadataDto<LightExerciseDto>>;
