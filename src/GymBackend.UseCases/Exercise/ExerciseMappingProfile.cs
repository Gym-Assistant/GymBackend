using AutoMapper;
using GymBackend.UseCases.Common.Dtos.Workout;
using GymBackend.UseCases.Exercise.EditExercise;

namespace GymBackend.UseCases.Exercise;

/// <summary>
/// Exercise mapping profile.
/// </summary>
public class ExerciseMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ExerciseMappingProfile()
    {
        // Command -> Entity.
        CreateMap<CreateOrUpdateExercisesCommand, Domain.Workouts.Exercise>();
        CreateMap<Domain.Workouts.Exercise, LightExerciseDto>().ReverseMap();
    }
}
