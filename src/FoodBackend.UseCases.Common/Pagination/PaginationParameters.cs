using System.ComponentModel.DataAnnotations;

namespace FoodBackend.UseCases.Common.Pagination;

/// <summary>
/// Pagination parameters for queries.
/// </summary>
public abstract record PaginationParameters
{
    /// <summary>
    /// Page number to return. Starts with 1.
    /// </summary>
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    /// <summary>
    /// Required page size (amount of items returned at a time).
    /// </summary>
    [Range(1, 1000)]
    public int PageSize { get; set; } = 100;
}
