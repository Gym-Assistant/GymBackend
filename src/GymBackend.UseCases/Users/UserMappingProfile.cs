using AutoMapper;
using GymBackend.Domain.Users;
using GymBackend.UseCases.Common.Dtos.Dtos;

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
        CreateMap<User, UserDto>();
    }
}
