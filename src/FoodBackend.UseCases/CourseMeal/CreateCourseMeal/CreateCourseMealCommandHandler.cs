﻿using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMeal;

/// <summary>
/// Create course meal command handler.
/// </summary>
internal class CreateCourseMealCommandHandler : BaseCommandHandler, IRequestHandler<CreateCourseMealCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateCourseMealCommandHandler(IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = Mapper.Map<Domain.MealStuffs.CourseMeal>(request);
        var mealType = await DbContext.MealTypes
            .GetAsync(mealType => mealType.Id == request.MealTypeId, cancellationToken);
        var courseMealDay = await DbContext.CourseMealDays
            .Include(courseMeal => courseMeal.CourseMeals)
            .GetAsync(courseMealDay => courseMealDay.Id == request.CourseMealDayId, cancellationToken);
        courseMeal.MealType = mealType;
        courseMeal.CourseMealDay = courseMealDay;
        courseMeal.UserId = loggedUserAccessor.GetCurrentUserId();
        if (request.CourseMealTime != null)
        {
            courseMeal.CreationTime = request.CourseMealTime.Value;
        }
        else
        {
            courseMeal.CreationTime = TimeOnly.FromDateTime(DateTime.UtcNow);
        }
        courseMealDay.CourseMeals.Add(courseMeal);
        await DbContext.CourseMeals.AddAsync(courseMeal, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return courseMeal.Id;
    }
}
