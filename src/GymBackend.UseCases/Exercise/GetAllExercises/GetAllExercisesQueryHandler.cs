using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.Workout;
using GymBackend.UseCases.Workout.GetAllWorkouts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace GymBackend.UseCases.Exercise.GetAllExercises;

/// <summary>
/// Handler for <see cref="GetAllExercisesQuery"/>.
/// </summary>
public class GetAllExercisesQueryHandler : BaseQueryHandler, IRequestHandler<GetAllExercisesQuery, IEnumerable<LightExerciseDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllExercisesQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IEnumerable<LightExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
    {
        var exersiceQuery = DbContext.Exercises
            .Where(exercise => exercise.CreatedById == request.UserId)
            .ProjectTo<LightExerciseDto>(Mapper.ConfigurationProvider);

        if (request.LastSyncedDate.HasValue)
        {
            exersiceQuery = exersiceQuery
                .Where(workout => workout.UpdatedAt > request.LastSyncedDate);
        }

        return await exersiceQuery.ToListAsync(cancellationToken);
    }
}
