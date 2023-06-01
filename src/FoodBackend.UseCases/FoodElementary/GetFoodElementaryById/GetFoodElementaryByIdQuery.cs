using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryById;

/// <summary>
/// Get food elementary with detail information by id query.
/// </summary>
public record GetFoodElementaryByIdQuery(Guid FoodElementaryId) : IRequest<DetailFoodElementaryDto>;
