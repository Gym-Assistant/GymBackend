using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.DeleteFoodElementaryById;

/// <summary>
/// Remove food by id command handler.
/// </summary>
internal class RemoveFoodElementaryByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveFoodElementaryByIdCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveFoodElementaryByIdCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveFoodElementaryByIdCommand request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodElementaries
            .GetAsync(food => food.Id == request.FoodElementaryId, cancellationToken);

        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't delete food elementary that you didn't create.");
        }
        
        DbContext.FoodElementaries.Remove(food);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
