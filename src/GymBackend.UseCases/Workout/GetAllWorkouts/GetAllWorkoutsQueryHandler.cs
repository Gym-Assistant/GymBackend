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
        var workouts = await DbContext.Workouts.Where(workout => workout.CreatedById == request.UserId)
            .ProjectTo<WorkoutDto>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return workouts;
    }
}
