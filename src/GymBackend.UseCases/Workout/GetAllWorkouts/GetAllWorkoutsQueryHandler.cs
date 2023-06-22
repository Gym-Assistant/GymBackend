using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.UseCases.Workout.GetAllWorkouts;

/// <summary>
/// Handler for <see cref="GetAllWorkoutsQuery"/>.
/// </summary>
public class GetAllWorkoutsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllWorkoutsQuery, IEnumerable<WorkoutDto>>
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
    public async Task<IEnumerable<WorkoutDto>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var workoutsQuery = DbContext.Workouts.Where(workout => workout.CreatedById == request.UserId)
            .ProjectTo<WorkoutDto>(Mapper.ConfigurationProvider);

        if (request.LastSyncedDate.HasValue)
        {
            workoutsQuery = workoutsQuery
                .Where(workout => workout.UpdatedAt > request.LastSyncedDate);
        }

        var workouts = await workoutsQuery.ToListAsync(cancellationToken);
        return workouts;
    }
}
