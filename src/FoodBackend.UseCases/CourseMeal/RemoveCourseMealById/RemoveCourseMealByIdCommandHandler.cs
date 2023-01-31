using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.RemoveCourseMealById;

/// <summary>
/// Remove food characteristic type by id command handler.
/// </summary>
internal class RemoveCourseMealByIdCommandHandler : IRequestHandler<RemoveCourseMealByIdCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveCourseMealByIdCommandHandler(IFoodDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveCourseMealByIdCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await dbContext.CourseMeals
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId,
                cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove course meal that you didn't create.");
        }

        dbContext.CourseMeals.Remove(courseMeal);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
