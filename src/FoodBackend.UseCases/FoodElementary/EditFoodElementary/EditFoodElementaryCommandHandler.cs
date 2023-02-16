using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.EditFoodElementary;

/// <summary>
/// Edit food elementary command handler.
/// </summary>
internal class EditFoodElementaryCommandHandler : BaseCommandHandler, IRequestHandler<EditFoodElementaryCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EditFoodElementaryCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc />
    public async Task<Unit> Handle(EditFoodElementaryCommand request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodElementaries
            .GetAsync(food => food.Id == request.Id, cancellationToken);

        if (food.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't edit food elementary that you didn't create.");
        }

        if (request.Name != null)
        {
            food.Name = request.Name;
        }

        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
