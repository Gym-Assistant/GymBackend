using FoodBackend.UseCases.FoodElementary.CreateFoodElementary;
using Microsoft.AspNetCore.Mvc.Rendering;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.DataAccess;
using GymBackend.UseCases.Users.AuthenticateUser;
using GymBackend.Web.Infrastructure.Jwt;
using GymBackend.Web.Infrastructure.Web;

namespace GymBackend.Web.Infrastructure.DependencyInjection;

/// <summary>
/// System specific dependencies.
/// </summary>
internal static class SystemModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddSingleton<IJsonHelper, SystemTextJsonHelper>();
        services.AddScoped<IAuthenticationTokenService, SystemJwtTokenService>();
        services.AddScoped<IAppDbContext, AppDbContext>();
        services.AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
        services.AddScoped<IAddDefaultFoodCharacteristic, AddDefaultFoodCharacteristic>();
    }
}
