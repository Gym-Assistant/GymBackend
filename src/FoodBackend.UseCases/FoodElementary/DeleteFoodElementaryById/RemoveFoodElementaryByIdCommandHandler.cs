using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.DeleteFoodElementaryById;

/// <summary>
/// Remove food by id command handler.
/// </summary>
internal class RemoveFoodElementaryByIdCommandHandler : IRequestHandler<RemoveFoodElementaryByIdCommand>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodElementaryByIdCommandHandler(IFoodDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodElementaryByIdCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.FoodElementaries
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't delete food elementary that you didn't create.");
        }
        
        dbContext.FoodElementaries.Remove(food);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
