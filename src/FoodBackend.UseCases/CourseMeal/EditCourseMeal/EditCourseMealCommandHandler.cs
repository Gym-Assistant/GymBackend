using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.EditCourseMeal;

/// <summary>
/// Edit food characteristic type handler.
/// </summary>
internal class EditCourseMealCommandHandler : IRequestHandler<EditCourseMealCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditCourseMealCommandHandler(ILoggedUserAccessor loggedUserAccessor, IFoodDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await dbContext.CourseMeals
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that you didn't create.");
        }
        
        if (request.MealTypeId != null)
        {
            courseMeal.MealTypeId = request.MealTypeId;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
