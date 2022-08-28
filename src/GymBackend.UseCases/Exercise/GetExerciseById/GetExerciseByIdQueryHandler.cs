using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Exercise.GetExerciseById;

/// <summary>
/// Handler for <see cref="GetExerciseByIdQuery"/>.
/// </summary>
public class GetExerciseByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetExerciseByIdQuery, LightExerciseDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetExerciseByIdQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<LightExerciseDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
    {
        var exercise = await DbContext.Exercises
                .ProjectTo<LightExerciseDto>(Mapper.ConfigurationProvider)
                .GetAsync(exercise => exercise.Id == request.ExerciseId, cancellationToken);

        return exercise;
    }
}
