using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Exercise.EditExercise;

/// <summary>
/// Handler for <see cref="EditExerciseCommand"/>.
/// </summary>
public class EditExerciseCommandHandler : BaseCommandHandler, IRequestHandler<EditExerciseCommand>
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
    public async Task<Unit> Handle(EditExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = await DbContext.Exercises.GetAsync(exercise => exercise.Id == request.Id, cancellationToken);
        if (exercise.CreatedById != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit exercise that you didn't create.");
        }

        if (request.Name != null)
        {
            exercise.Name = request.Name;
        }

        if (request.Description != null)
        {
            exercise.Description = request.Description;
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
