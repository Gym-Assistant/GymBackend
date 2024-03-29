﻿namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food recipe DTO with detail information.
/// </summary>
public record DetailFoodRecipeDto
{
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Food recipe name.
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Id of user who created recipe.
    /// </summary>
    public Guid? UserId { get; init; }
    
    /// <summary>
    /// Is food recipe default statement.
    /// </summary>
    public bool IsDefault { get; init; }

    /// <summary>
    /// Ingredients collection.
    /// </summary>
    public ICollection<FoodElementaryInRecipeDto> Ingredients { get; init; }

    /// <summary>
    /// Food recipe characteristics sum information.
    /// </summary>
    public ICollection<FoodCharacteristicSumDto> CharacteristicsSum { get; set; }
}
