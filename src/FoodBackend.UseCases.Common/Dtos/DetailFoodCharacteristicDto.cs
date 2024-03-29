﻿namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food characteristic DTO with detail information.
/// </summary>
public record DetailFoodCharacteristicDto
{
    /// <summary>
    /// Food characteristic id.
    /// </summary>
    public Guid FoodCharacteristicId { get; init; }
    
    /// <summary>
    /// Food characteristic type id.
    /// </summary>
    public Guid CharacteristicTypeId { get; init; }

    /// <summary>
    /// Food characteristic name.
    /// </summary>
    public string CharacteristicName { get; init; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; init; }
}
