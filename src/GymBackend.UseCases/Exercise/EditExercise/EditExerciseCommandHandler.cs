using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using GymBackend.UseCases.Common.Dtos.Workout;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Exercise.EditExercise;

/// <summary>
/// Handler for <see cref="CreateOrUpdateExercisesCommand"/>.
/// </summary>
public class EditExerciseCommandHandler : BaseCommandHandler, IRequestHandler<CreateOrUpdateExercisesCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditExerciseCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task Handle(CreateOrUpdateExercisesCommand request, CancellationToken cancellationToken)
    {
        var userId = loggedUserAccessor.GetCurrentUserId();
        foreach (var exercise in request.Exercises)
        {
            await HandleExerciseAsync(exercise, userId, CancellationToken.None);
        }

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task HandleExerciseAsync(LightExerciseDto lightExerciseDto, Guid userId, CancellationToken cancellationToken)
    {
        var exercise = await DbContext.Exercises.FirstOrDefaultAsync(exercise => exercise.Id == lightExerciseDto.Id, cancellationToken);

        if (exercise == null)
        {
            var exerciseToCreate = Mapper.Map<Domain.Workouts.Exercise>(lightExerciseDto);
            exerciseToCreate.CreatedById = userId;
            DbContext.Exercises.Add(exerciseToCreate);
            return;
        }
        if (lightExerciseDto.Name != null)
        {
            exercise.Name = lightExerciseDto.Name;
        }

        if (lightExerciseDto.Description != null)
        {
            exercise.Description = lightExerciseDto.Description;
        }
    }
}
