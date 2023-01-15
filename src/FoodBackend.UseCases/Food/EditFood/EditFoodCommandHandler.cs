using AutoMapper;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.Food.EditFood;

/// <summary>
/// Edit food command handler.
/// </summary>
internal class EditFoodCommandHandler : IRequestHandler<EditFoodCommand>
{
    private readonly IFoodDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodCommandHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodCommand request, CancellationToken cancellationToken)
    {
        var food = await dbContext.Foods
            .GetAsync(food => food.Id == request.Id, cancellationToken);

        if (request.Name != null)
        {
            food.Name = request.Name;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
