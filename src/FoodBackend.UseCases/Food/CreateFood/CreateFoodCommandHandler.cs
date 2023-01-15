using AutoMapper;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace FoodBackend.UseCases.Food.CreateFood;

/// <summary>
/// Crete food command handler.
/// </summary>
internal class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodCommandHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
        var food = mapper.Map<Domain.Foodstuffs.Food>(request);
        dbContext.Foods.Add(food);
        await dbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
