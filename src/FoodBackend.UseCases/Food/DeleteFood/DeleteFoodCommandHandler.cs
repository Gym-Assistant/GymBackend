using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.Food.DeleteFood;

/// <summary>
/// Delete food command handler.
/// </summary>
internal class DeleteFoodCommandHandler : BaseCommandHandler, IRequestHandler<DeleteFoodCommand>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public DeleteFoodCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext) { }

    /// <inheritdoc/>
    public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
    {
        var food = await DbContext.Foods.GetAsync(food => food.Id == request.foodId, cancellationToken);

        DbContext.Foods.Remove(food);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
