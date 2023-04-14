using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.RemoveCourseMealById;

/// <summary>
/// Remove food characteristic type by id command handler.
/// </summary>
internal class RemoveCourseMealByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveCourseMealByIdCommand, Unit>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveCourseMealByIdCommandHandler(IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveCourseMealByIdCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId,
                cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove course meal that you didn't create.");
        }

        DbContext.CourseMeals.Remove(courseMeal);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
