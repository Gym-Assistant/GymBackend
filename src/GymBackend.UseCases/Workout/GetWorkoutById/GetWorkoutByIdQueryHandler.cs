using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Workout.GetWorkoutById;

/// <summary>
/// Handler for <see cref="GetWorkoutByIdQuery"/>.
/// </summary>
public class GetWorkoutByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetWorkoutByIdQuery, WorkoutDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetWorkoutByIdQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<WorkoutDto> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
    {
        var workout = await DbContext.Workouts.ProjectTo<WorkoutDto>(Mapper.ConfigurationProvider)
            .GetAsync(workout => workout.Id == request.WorkoutId, cancellationToken);

        return workout;
    }
}
