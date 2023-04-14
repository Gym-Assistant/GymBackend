using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.AddCourseMealToDay;

/// <summary>
/// Add course meal to course meal day command handler.
/// </summary>
internal class AddCourseMealToDayCommandHandler : BaseCommandHandler, IRequestHandler<AddCourseMealToDayCommand, Unit>
{
    private ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public AddCourseMealToDayCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<Unit> Handle(AddCourseMealToDayCommand request, CancellationToken cancellationToken)
    {
        var courseMealDay = await DbContext.CourseMealDays
            .Include(courseMealDay => courseMealDay.CourseMeals)
            .GetAsync(courseMealDay => courseMealDay.Id == request.CourseMealDayId, cancellationToken);
        if (courseMealDay.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit course meal day that not belong to you.");
        }
        var courseMeal = await DbContext.CourseMeals
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId, cancellationToken);
        if (courseMeal.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't add not your course meal to day.");
        }
        courseMealDay.CourseMeals.Add(courseMeal);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
