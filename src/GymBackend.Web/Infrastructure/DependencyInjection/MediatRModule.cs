using FoodBackend.UseCases.FoodElementary.CreateFoodElementary;
using MediatR;
using GymBackend.UseCases.Users.AuthenticateUser;

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
        /*services.AddMediatR(typeof(LoginUserCommand));
        services.AddMediatR(typeof(CreateFoodElementaryCommand));*/
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFoodElementaryCommand).Assembly));
    }
}
