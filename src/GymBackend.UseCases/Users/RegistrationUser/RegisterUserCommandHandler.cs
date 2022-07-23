using GymBackend.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Saritasa.Tools.Domain.Exceptions;

namespace GymBackend.UseCases.Users.RegistrationUser;

/// <summary>
/// Handler for <see cref="RegisterUserCommand"/>.
/// </summary>
internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly UserManager<User> userManager;
    private readonly ILogger<RegisterUserCommandHandler> logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RegisterUserCommandHandler(
        UserManager<User> userManager,
        ILogger<RegisterUserCommandHandler> logger)
    {
        this.userManager = userManager;
        this.logger = logger;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User()
        {
            Email = request.Email,
            UserName = request.Email,
        };

        var result = await userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
        {
            throw new DomainException("Error in login or password");
        }

        var userId = await userManager.GetUserIdAsync(newUser);
        return Guid.Parse(userId);
    }
}
