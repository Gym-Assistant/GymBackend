using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.GetFoodElementaryDetailById;

/// <summary>
/// Get food elementary with detail information by id query.
/// </summary>
public record GetFoodElementaryDetailByIdQuery(Guid FoodElementaryId) : IRequest<DetailFoodElementaryDto>;
