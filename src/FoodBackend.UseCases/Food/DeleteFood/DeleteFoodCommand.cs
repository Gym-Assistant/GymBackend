using MediatR;

namespace FoodBackend.UseCases.Food.DeleteFood;

/// <summary>
/// Delete food command.
/// </summary>
/// <param name="foodId"></param>
public record DeleteFoodCommand(Guid foodId) : IRequest;
