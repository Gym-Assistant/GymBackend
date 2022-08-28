using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;

namespace GymBackend.UseCases.Exercise.CreateExercise;

/// <summary>
/// Handler for <see cref="CreateExerciseCommand"/>.
/// </summary>
public class CreateExerciseCommandHandler : BaseCommandHandler, IRequestHandler<CreateExerciseCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateExerciseCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = new Domain.Workouts.Exercise()
        {
            Name = request.Name,
            Description = request.Description,
            CreatedById = loggedUserAccessor.GetCurrentUserId(),
            CreatedAt = DateTime.UtcNow,
        };
        DbContext.Exercises.Add(exercise);
        await DbContext.SaveChangesAsync(cancellationToken);

        return exercise.Id;
    }
}
