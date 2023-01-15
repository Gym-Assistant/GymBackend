using FoodBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.Food.DeleteFoodById;

/// <summary>
/// Remove food by id command handler.
/// </summary>
internal class RemoveFoodByIdCommandHandler : IRequestHandler<RemoveFoodByIdCommand>
{
    private readonly IFoodDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodByIdCommandHandler(IFoodDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodByIdCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.Foods
            .GetAsync(food => food.Id == request.FoodId, cancellationToken);
        dbContext.Foods.Remove(food);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
