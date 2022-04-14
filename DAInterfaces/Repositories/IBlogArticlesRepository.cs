﻿using KMaSA.Models;
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
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<BlogArticleDto>> GetAsync(int page, int limit);

    /// <summary>
    /// Gets article by id.
    /// </summary>
    /// <param name="id">Blog article id.</param>
    /// <returns>Article with specified id.</returns>
    Task<BlogArticleDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new blog article.
    /// </summary>
    /// <param name="blogArticleDto">New blog article.</param>
    /// <returns>Id of blog article.</returns>
    Task<int> AddAsync(BlogArticleDto blogArticleDto);

    /// <summary>
    /// Updates blog article.
    /// </summary>
    /// <param name="blogArticleId">Id of the article.</param>
    /// <param name="blogArticleDto">New values.</param>
    /// <returns>True, if article was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int blogArticleId, BlogArticleDto blogArticleDto);

    /// <summary>
    /// Removes blog article.
    /// </summary>
    /// <param name="blogArticleId">Id of the article.</param>
    /// <returns>True, if article was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int blogArticleId);
}