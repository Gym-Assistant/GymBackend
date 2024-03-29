﻿using System.ComponentModel.DataAnnotations;
using FoodBackend.Domain.MealStuffs;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food elementary entity.
/// </summary>
public record FoodElementary
{
    /// <summary>
    /// Food id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Food name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id of creator.
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// User creator.
    /// </summary>
    public User? User { get; set; }
    
    /// <summary>
    /// Is food default statement.
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Food characteristics collection.
    /// </summary>
    public ICollection<FoodCharacteristic> Characteristics { get; set; }
    
    /// <summary>
    /// Related food recipes.
    /// </summary>
    public ICollection<FoodRecipe> FoodRecipes { get; set; }
    
    /// <summary>
    /// Related course meals.
    /// </summary>
    public ICollection<CourseMeal> CourseMeals { get; set; }
}
