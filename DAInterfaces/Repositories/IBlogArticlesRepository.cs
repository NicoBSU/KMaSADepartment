using KMaSA.Models;
using KMaSA.Models.DTO;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for blog articles storage managing.
/// </summary>
public interface IBlogArticlesRepository
{
    /// <summary>
    /// Gets items with specified count.
    /// </summary>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<BlogArticleDto>> Get(int offset, int limit);

    /// <summary>
    /// Gets article by id.
    /// </summary>
    /// <param name="id">Blog article id.</param>
    /// <returns>Article with specified id.</returns>
    Task<BlogArticleDto> GetById(int id);

    /// <summary>
    /// Adds new blog article.
    /// </summary>
    /// <param name="blogArticleDto">New blog article.</param>
    /// <returns>Id of blog article.</returns>
    Task<int> Add(BlogArticleDto blogArticleDto);

    /// <summary>
    /// Updates blog article.
    /// </summary>
    /// <param name="blogArticleId">Id of the article.</param>
    /// <param name="blogArticleDto">New values.</param>
    /// <returns>True, if article was updated, otherwise, false.</returns>
    Task<bool> Update(int blogArticleId, BlogArticleDto blogArticleDto);

    /// <summary>
    /// Removes blog article.
    /// </summary>
    /// <param name="blogArticleId">Id of the article.</param>
    /// <returns>True, if article was deleted, otherwise, false.</returns>
    Task<bool> Delete(int blogArticleId);
}