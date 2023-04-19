using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Exercise.RemoveExercise;

/// <summary>
/// Handler for <see cref="RemoveExerciseByIdCommand"/>.
/// </summary>
public class RemoveExerciseByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveExerciseByIdCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveExerciseByIdCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task Handle(RemoveExerciseByIdCommand request, CancellationToken cancellationToken)
    {
        var exercise = await DbContext.Exercises.GetAsync(exercise => exercise.Id == request.ExerciseId, cancellationToken);
        if (exercise.CreatedById != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You are cannot remove this exercise");
        }

        DbContext.Exercises.Remove(exercise);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
