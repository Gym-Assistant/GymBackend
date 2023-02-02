﻿using MediatR;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMeal;

/// <summary>
/// Create Course meal.
/// </summary>
public record CreateCourseMealCommand : IRequest<Guid>
{
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; set; }
}