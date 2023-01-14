﻿using FoodBackend.Domain.Foodstuffs;
using Microsoft.EntityFrameworkCore;

namespace FoodBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Abstraction for food assistant database context.
/// </summary>
public interface IFoodDbContext : IDisposable
{
    /// <summary>
    /// Foods.
    /// </summary>
    DbSet<Food> Foods { get; }

    /// <summary>
    /// Food characteristics.
    /// </summary>
    DbSet<FoodCharacteristic> FoodCharacteristics { get; }

    /// <summary>
    /// Food characteristic types.
    /// </summary>
    DbSet<FoodCharacteristicType> FoodCharacteristicTypes { get; }
}