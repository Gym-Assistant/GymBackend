using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.RemoveElementaryFromCourseMeal;

/// <summary>
/// Remove food elementary from course meal command handler.
/// </summary>
public class RemoveElementaryFromCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<RemoveElementaryFromCourseMealCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveElementaryFromCourseMealCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task Handle(RemoveElementaryFromCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodElementaries)
            .Include(courseMeal => courseMeal.ConsumedElementaryWeights)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that you didn't create.");
        }
        
        var foodElementary = await DbContext.FoodElementaries
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        courseMeal.ConsumedFoodElementaries.Remove(foodElementary);
        var elementaryWeight = await DbContext.ConsumedElementaryWeights
            .GetAsync(foodElementaryWeight => foodElementaryWeight.FoodElementaryId == request.FoodElementaryId &&
                                              foodElementaryWeight.CourseMealId == request.CourseMealId, cancellationToken);
        DbContext.ConsumedElementaryWeights.Remove(elementaryWeight);
        courseMeal.ConsumedElementaryWeights.Remove(elementaryWeight);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
