using AutoMapper;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMeal;

/// <summary>
/// Create course meal command handler.
/// </summary>
internal class CreateCourseMealCommandHandler : IRequestHandler<CreateCourseMealCommand, Guid>
{
    private readonly IFoodDbContext dbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateCourseMealCommandHandler(IFoodDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(CreateCourseMealCommand request, CancellationToken cancellationToken)
    {
        var courseMeal = mapper.Map<Domain.MealStuffs.CourseMeal>(request);
        var mealType = await dbContext.MealTypes
            .GetAsync(mealType => mealType.Id == request.MealTypeId,
                cancellationToken);
        courseMeal.MealType = mealType;
        courseMeal.UserId = loggedUserAccessor.GetCurrentUserId();
        courseMeal.CreationDate = DateTime.UtcNow;
        dbContext.CourseMeals.Add(courseMeal);
        await dbContext.SaveChangesAsync(cancellationToken);

        return courseMeal.Id;
    }
}
