using MediatR;

namespace FoodBackend.UseCases.Food.DeleteFoodById;

/// <summary>
/// Remove food by id command.
/// </summary>
public record RemoveFoodByIdCommand(Guid FoodId) : IRequest;
