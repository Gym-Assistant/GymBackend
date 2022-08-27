﻿using GymBackend.UseCases.Common.Dtos.Workout;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace GymBackend.UseCases.Workout.GetAllWorkouts;

/// <summary>
/// Get all workouts query.
/// </summary>
public record GetAllWorkoutsQuery : PageQueryFilter, IRequest<PagedListMetadataDto<LightWorkoutDto>>
{
    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }
}
