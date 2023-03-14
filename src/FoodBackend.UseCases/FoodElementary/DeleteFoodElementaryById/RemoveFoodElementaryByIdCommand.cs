using MediatR;

namespace FoodBackend.UseCases.FoodElementary.DeleteFoodElementaryById;

/// <summary>
/// Remove food elementary by id command.
/// </summary>
public record RemoveFoodElementaryByIdCommand(Guid FoodElementaryId) : IRequest;
