using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

namespace FoodBackend.UseCases.Food.AddFood;

internal class CreateFoodCommandHandler : BaseCommandHandler, IRequestHandler<CreateFoodCommand, Guid>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodCommandHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext) { }

    /// <inheritdoc/>
    public async Task<Guid> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        var food = Mapper.Map<GymBackend.Domain.FoodRecords.Food>(request);

        DbContext.Foods.Add(food);
        await DbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
