using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.Food.UpdateFood;

/// <summary>
/// Update food by id command handler.
/// </summary>
internal class UpdateFoodCommandHandler : BaseCommandHandler, IRequestHandler<UpdateFoodCommand>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public UpdateFoodCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext) { }

    /// <inheritdoc/>
    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        var food = await DbContext.Foods.GetAsync(food => food.Id == request.Id, cancellationToken);

        if (request.Name != null)
        {
            food.Name = request.Name;
        }

        if (request.Callories != null)
        {
            food.Callories = request.Callories;
        }

        if (request.Protein != null)
        {
            food.Protein = request.Protein;
        }

        if (request.Carbohydrates != null)
        {
            food.Carbohydrates = request.Carbohydrates;
        }

        if (request.Fat != null)
        {
            food.Fat = request.Fat;
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
