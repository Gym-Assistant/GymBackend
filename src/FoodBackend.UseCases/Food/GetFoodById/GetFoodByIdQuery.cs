using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.Food.GetFoodById;

/// <summary>
/// Get food by id query.
/// </summary>
/// <param name="FoodId"></param>
public record GetFoodByIdQuery(Guid FoodId) : IRequest<LightFoodDto>;
