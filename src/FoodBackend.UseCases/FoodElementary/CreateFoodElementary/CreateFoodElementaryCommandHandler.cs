using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
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
    private readonly IAddDefaultFoodCharacteristic defaultCharacteristic;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateFoodElementaryCommandHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor, IAddDefaultFoodCharacteristic defaultCharacteristic) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.defaultCharacteristic = defaultCharacteristic;
    }
    
    /// <inheritdoc />>
    public async Task<Guid> Handle(CreateFoodElementaryCommand request, CancellationToken cancellationToken)
    {
        const double proteinCoefficient = 4.0;
        const double carboHydrateCoefficient = 4.0;
        const double fatCoefficient = 9.0;
        var food = Mapper.Map<Domain.Foodstuffs.FoodElementary>(request);
        food.UserId = loggedUserAccessor.GetCurrentUserId();
        await DbContext.FoodElementaries.AddAsync(food, cancellationToken);
        await defaultCharacteristic.AddDefaultCharacteristic(FoodCharacteristicDefaults.ProteinId, food, request.ProteinValue, cancellationToken);
        await defaultCharacteristic.AddDefaultCharacteristic(FoodCharacteristicDefaults.FatId, food, request.FatValue, cancellationToken);
        await defaultCharacteristic.AddDefaultCharacteristic(FoodCharacteristicDefaults.CarbohydrateId, food, request.CarbohydrateValue, cancellationToken);
        await defaultCharacteristic.AddDefaultCharacteristic(FoodCharacteristicDefaults.EmptyCaloriesId, food, request.EmptyCaloriesValue, cancellationToken);
        var caloriesValue = proteinCoefficient * request.ProteinValue +
                            carboHydrateCoefficient * request.CarbohydrateValue +
                            fatCoefficient * request.FatValue + request.EmptyCaloriesValue;
        await defaultCharacteristic.AddDefaultCharacteristic(FoodCharacteristicDefaults.CaloriesId, food, caloriesValue, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return food.Id;
    }
}
