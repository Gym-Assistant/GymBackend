using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.AddElementaryToCourseMeal;

/// <summary>
/// Add elementary to course meal handler.
/// </summary>
internal class AddElementaryToCourseMealCommandHandler : IRequestHandler<AddElementaryToCourseMealCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddElementaryToCourseMealCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<Unit> Handle(AddElementaryToCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await dbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodElementaries)
            .Include(courseMeal => courseMeal.ConsumedElementaryWeights)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that not belong to you.");
        }
        
        var foodElementary = await dbContext.FoodElementaries
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        courseMeal.ConsumedFoodElementaries.Add(foodElementary);

        var consumedElementaryWeight = new ConsumedElementaryWeight
        {
            FoodElementaryId = foodElementary.Id,
            FoodElementary = foodElementary,
            CourseMealId = courseMeal.Id,
            CourseMeal = courseMeal,
            Weight = request.Weight,
            UserId = loggedUserAccessor.GetCurrentUserId()
        };
        dbContext.ConsumedElementaryWeights.Add(consumedElementaryWeight);
        courseMeal.ConsumedElementaryWeights.Add(consumedElementaryWeight);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
