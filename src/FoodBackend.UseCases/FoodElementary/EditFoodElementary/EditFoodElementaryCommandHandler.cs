using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.EditFoodElementary;

/// <summary>
/// Edit food elementary command handler.
/// </summary>
internal class EditFoodElementaryCommandHandler : IRequestHandler<EditFoodElementaryCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodElementaryCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodElementaryCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodElementaries
            .GetAsync(food => food.Id == request.Id, cancellationToken);

        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food elementary that you didn't create.");
        }

        if (request.Name != null)
        {
            food.Name = request.Name;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
