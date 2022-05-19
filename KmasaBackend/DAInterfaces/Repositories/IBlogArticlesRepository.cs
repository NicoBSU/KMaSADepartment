using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.BlogArticles;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for blog articles storage managing.
/// </summary>
public interface IBlogArticlesRepository
{
    /// <summary>
    /// Gets items with specified count.
    /// </summary>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<GetBlogArticleDto>> GetAsync(int page, int limit);

    /// <summary>
    /// Gets article by id.
    /// </summary>
    /// <param name="id">Blog article id.</param>
    /// <returns>Article with specified id.</returns>
    Task<GetBlogArticleDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new blog article.
    /// </summary>
    /// <param name="blogArticleDto">New blog article.</param>
    /// <returns>Id of blog article.</returns>
    Task<int> AddAsync(AddBlogArticleDto blogArticleDto);

    /// <summary>
    /// Updates blog article.
    /// </summary>
    /// <param name="blogArticleId">Id of the article.</param>
    /// <param name="blogArticleDto">New values.</param>
    /// <returns>True, if article was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int blogArticleId, AddBlogArticleDto blogArticleDto);

    /// <summary>
    /// Removes blog article.
    /// </summary>
    /// <param name="blogArticleId">Id of the article.</param>
    /// <returns>True, if article was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int blogArticleId);

    /// <summary>
    /// Updates article picture.
    /// </summary>
    /// <param name="blogArticleId">Id of the article</param>
    /// <param name="pictureLink">Link to picture storage.</param>
    /// <returns>True, if the link was updated, otherwise, false</returns>
    Task<bool> UpdatePicture(int blogArticleId, PhotoDto picture);
}