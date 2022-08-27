using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace GymBackend.UseCases.Workout.GetAllWorkouts;

/// <summary>
/// Handler for <see cref="GetAllWorkoutsQuery"/>.
/// </summary>
public class GetAllWorkoutsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllWorkoutsQuery, PagedListMetadataDto<LightWorkoutDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="dbContext"></param>
    public GetAllWorkoutsQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightWorkoutDto>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var workoutQuery = DbContext.Workouts.Where(workout => workout.CreatedById == request.UserId)
            .ProjectTo<LightWorkoutDto>(Mapper.ConfigurationProvider);

        var pagedWorkouts = await EFPagedListFactory.FromSourceAsync(workoutQuery, request.Page, request.PageSize, cancellationToken);
        return pagedWorkouts.ToMetadataObject();
    }
}
