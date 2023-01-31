using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.MealType.RemoveMealTypeById;

/// <summary>
/// Remove meal type by id command handler.
/// </summary>
internal class RemoveMealTypeByIdCommandHandler : IRequestHandler<RemoveMealTypeByIdCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveMealTypeByIdCommandHandler(IFoodDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveMealTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var mealType = await dbContext.MealTypes
            .GetAsync(mealType => mealType.Id == request.MealTypeId,
                cancellationToken);
        if (mealType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove meal type that you didn't create.");
        }

        dbContext.MealTypes.Remove(mealType);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
