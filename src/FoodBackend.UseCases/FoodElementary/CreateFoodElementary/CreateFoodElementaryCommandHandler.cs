using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.CreateFoodElementary;

/// <summary>
/// Crete food elementary command handler.
/// </summary>
internal class CreateFoodElementaryCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateFoodElementaryCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodElementaryCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodElementaryCommand request, CancellationToken cancellationToken)
    {
        var food = Mapper.Map<Domain.Foodstuffs.FoodElementary>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        DbContext.FoodElementaries.Add(food);
        await DbContext.SaveChangesAsync(cancellationToken);

        return food.Id;
    }
}
