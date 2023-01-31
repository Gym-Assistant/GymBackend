using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.MealType.EditMealType;

/// <summary>
/// Edit meal type handler.
/// </summary>
internal class EditMealTypeCommandHandler : IRequestHandler<EditMealTypeCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditMealTypeCommandHandler(ILoggedUserAccessor loggedUserAccessor, IFoodDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditMealTypeCommand request, CancellationToken cancellationToken)
    {
        var mealType = await dbContext.MealTypes
            .GetAsync(mealType => mealType.Id == request.MealTypeId, cancellationToken);
        if (mealType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit meal type that you didn't create.");
        }
        
        if (request.Name != null)
        {
            mealType.Name = request.Name;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
