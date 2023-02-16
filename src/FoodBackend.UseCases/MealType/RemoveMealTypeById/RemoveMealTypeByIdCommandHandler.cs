using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.MealType.RemoveMealTypeById;

/// <summary>
/// Remove meal type by id command handler.
/// </summary>
internal class RemoveMealTypeByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveMealTypeByIdCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveMealTypeByIdCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveMealTypeByIdCommand request, CancellationToken cancellationToken)
    {
        var mealType = await DbContext.MealTypes
            .GetAsync(mealType => mealType.Id == request.MealTypeId,
                cancellationToken);
        if (mealType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove meal type that you didn't create.");
        }

        DbContext.MealTypes.Remove(mealType);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
