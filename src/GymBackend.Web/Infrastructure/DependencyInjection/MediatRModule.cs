using MediatR;
using GymBackend.UseCases.Users.AuthenticateUser;
using FoodBackend.UseCases.Food.AddFood;
using System.Reflection;

namespace GymBackend.Web.Infrastructure.DependencyInjection;

/// <summary>
/// Register Mediator as dependency.
/// </summary>
internal static class MediatRModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddMediatR(typeof(LoginUserCommand).Assembly);
        services.AddMediatR(typeof(CreateFoodCommand).Assembly);
    }
}
