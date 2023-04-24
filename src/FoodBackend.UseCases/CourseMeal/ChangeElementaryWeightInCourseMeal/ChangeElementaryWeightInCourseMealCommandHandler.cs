using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.ChangeElementaryWeightInCourseMeal;

/// <summary>
/// Change elementary weight in course meal command handler.
/// </summary>
internal class ChangeElementaryWeightInCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<ChangeElementaryWeightInCourseMealCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ChangeElementaryWeightInCourseMealCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task Handle(ChangeElementaryWeightInCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Include(courseMeal => courseMeal.ConsumedFoodElementaries)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal that you didn't create.");
        }
        
        var foodElementary = await DbContext.FoodElementaries
            .GetAsync(foodElementary => foodElementary.Id == request.FoodElementaryId, cancellationToken);
        if (!courseMeal.ConsumedFoodElementaries.Contains(foodElementary))
        {
            throw new NotFoundException("There is no such food elementary in current course meal.");
        }
        var elementaryWeight = await DbContext.ConsumedElementaryWeights
            .GetAsync(foodElementaryWeight => foodElementaryWeight.FoodElementaryId == request.FoodElementaryId &&
                                              foodElementaryWeight.CourseMealId == request.CourseMealId, cancellationToken);
        elementaryWeight.Weight = request.Weight;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
