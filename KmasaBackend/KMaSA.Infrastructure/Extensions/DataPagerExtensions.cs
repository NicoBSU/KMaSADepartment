using KMaSA.Models;
using Microsoft.EntityFrameworkCore;

namespace KMaSA.Infrastructure.Extensions;

/// <summary>
/// Extension for data pagination.
/// </summary>
public static class DataPagerExtensions
{
    /// <summary>
    /// Creates paged model of collection.
    /// </summary>
    /// <param name="queryCollection"><see cref="IQueryable{T}"/> collection to paginate.</param>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items per page.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <typeparam name="T">Type of collection's item</typeparam>
    /// <returns>Paged model.</returns>
    public static async Task<PagedModel<T>> PaginateAsync<T>(
        this IQueryable<T> queryCollection,
        int page,
        int limit,
        CancellationToken cancellationToken)
    {
        page = page <= 0 ? 1 : page;
        var start = (page - 1) * limit;

        var items = queryCollection.Skip(start).Take(limit).AsEnumerable();

        var count = await queryCollection.CountAsync(cancellationToken);
        return new PagedModel<T>
        {
            PageSize = limit,
            CurrentPage = page,
            TotalCount = count,
            Items = items
        };
    }
}