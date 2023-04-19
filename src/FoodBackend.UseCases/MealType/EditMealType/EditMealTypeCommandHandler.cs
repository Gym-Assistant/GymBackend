using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.MealType.EditMealType;

/// <summary>
/// Edit meal type handler.
/// </summary>
internal class EditMealTypeCommandHandler : BaseCommandHandler, IRequestHandler<EditMealTypeCommand, Unit>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditMealTypeCommandHandler(ILoggedUserAccessor loggedUserAccessor, IMapper mapper,
        IAppDbContext dbContext) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditMealTypeCommand request, CancellationToken cancellationToken)
    {
        var mealType = await DbContext.MealTypes
            .GetAsync(mealType => mealType.Id == request.MealTypeId, cancellationToken);
        if (mealType.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit meal type that you didn't create.");
        }
        if (request.Name != null)
        {
            mealType.Name = request.Name;
        }
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
