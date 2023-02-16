using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.AddElementaryToCourseMeal;

/// <summary>
/// Add elementary to course meal handler.
/// </summary>
internal class AddElementaryToCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<AddElementaryToCourseMealCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddElementaryToCourseMealCommandHandler(IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<Unit> Handle(AddElementaryToCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodElementaries)
            .Include(courseMeal => courseMeal.ConsumedElementaryWeights)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that not belong to you.");
        }
        
        var foodElementary = await DbContext.FoodElementaries
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
        DbContext.ConsumedElementaryWeights.Add(consumedElementaryWeight);
        courseMeal.ConsumedElementaryWeights.Add(consumedElementaryWeight);
        
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
