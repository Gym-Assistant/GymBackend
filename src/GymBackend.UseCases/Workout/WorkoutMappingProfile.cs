using AutoMapper;
using GymBackend.Domain.Workouts;
using GymBackend.UseCases.Common.Dtos.Workout;

namespace GymBackend.UseCases.Workout;

/// <summary>
/// Workout mapping profile.
/// </summary>
public class WorkoutMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public WorkoutMappingProfile()
    {
        // Entity -> Dto.
        CreateMap<Domain.Workouts.Workout, WorkoutDto>();
        CreateMap<Domain.Workouts.Workout, LightWorkoutDto>();
        CreateMap<Set, SetsDto>();
        CreateMap<TrainSession, TrainSessionDto>();
    }
}
