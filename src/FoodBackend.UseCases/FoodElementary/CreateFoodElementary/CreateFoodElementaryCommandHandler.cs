using AutoMapper;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.CreateFoodElementary;

/// <summary>
/// Crete food elementary command handler.
/// </summary>
internal class CreateFoodElementaryCommandHandler : IRequestHandler<CreateFoodElementaryCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodElementaryCommandHandler(IFoodDbContext dbContext, IMapper mapper, ILoggedUserAccessor loggedUserAccessor)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodElementaryCommand request, CancellationToken cancellationToken)
    {
        var food = mapper.Map<Domain.Foodstuffs.FoodElementary>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        dbContext.FoodElementaries.Add(food);
        await dbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
