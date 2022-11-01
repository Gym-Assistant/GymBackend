using FoodBackend.UseCases.Food;
using GymBackend.UseCases.Users.AuthenticateUser;
using System.Reflection;

namespace GymBackend.Web.Infrastructure.DependencyInjection;

/// <summary>
/// Register AutoMapper dependencies.
/// </summary>
public class AutoMapperModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(TokenModel).Assembly);
        services.AddAutoMapper(
            typeof(FoodMappingProfile).Assembly);
    }
}
