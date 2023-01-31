using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryById;

/// <summary>
/// Get food elementary by id query.
/// </summary>
/// <param name="FoodId"></param>
public record GetFoodElementaryByIdQuery(Guid FoodElementaryId) : IRequest<LightFoodElementaryDto>;
