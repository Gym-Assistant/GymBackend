using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.EditCourseMeal;

/// <summary>
/// Edit food characteristic type handler.
/// </summary>
internal class EditCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<EditCourseMealCommand, Unit>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditCourseMealCommandHandler(ILoggedUserAccessor loggedUserAccessor, IAppDbContext dbContext,
        IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that you haven't created.");
        }
        
        if (request.MealTypeId != null)
        {
            courseMeal.MealTypeId = request.MealTypeId;
        }

        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
