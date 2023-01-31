using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace FoodBackend.UseCases.MealType.CreateMealType;

/// <summary>
/// Create meal type command handler.
/// </summary>
internal class CreateMealTypeCommandHandler : IRequestHandler<CreateMealTypeCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateMealTypeCommandHandler(IFoodDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateMealTypeCommand request, CancellationToken cancellationToken)
    {
        var mealType = mapper.Map<Domain.MealStuffs.MealType>(request);
        mealType.UserId = loggedUserAccessor.GetCurrentUserId();
        dbContext.MealTypes.Add(mealType);
        await dbContext.SaveChangesAsync(cancellationToken);

        return mealType.Id;
    }
}
