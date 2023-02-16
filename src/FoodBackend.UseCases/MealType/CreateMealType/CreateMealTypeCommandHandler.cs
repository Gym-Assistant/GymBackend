using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

namespace FoodBackend.UseCases.MealType.CreateMealType;

/// <summary>
/// Create meal type command handler.
/// </summary>
internal class CreateMealTypeCommandHandler : BaseCommandHandler, IRequestHandler<CreateMealTypeCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateMealTypeCommandHandler(IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateMealTypeCommand request, CancellationToken cancellationToken)
    {
        var mealType = Mapper.Map<Domain.MealStuffs.MealType>(request);
        mealType.UserId = loggedUserAccessor.GetCurrentUserId();
        await DbContext.MealTypes.AddAsync(mealType, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return mealType.Id;
    }
}
