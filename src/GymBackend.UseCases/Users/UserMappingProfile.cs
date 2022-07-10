using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.UseCases.Common.Dtos.User;
using GymBackend.UseCases.Users.UpdateUserProfile;

namespace GymBackend.UseCases.Users;

/// <summary>
/// User mapping profile.
/// </summary>
public class UserMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public UserMappingProfile()
    {
        // Entity -> Dto.
        CreateMap<User, UserDto>();
        CreateMap<User, UserDetailsDto>();
        CreateMap<User, UserProfileDto>();

        // Command -> Entity.
        CreateMap<UpdateUserProfileCommand, User>();
    }
}
