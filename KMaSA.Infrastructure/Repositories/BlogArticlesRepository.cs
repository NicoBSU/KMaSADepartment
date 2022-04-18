using AutoMapper;
using DAInterfaces.Repositories;
using KMaSA.Infrastructure.EF;
using KMaSA.Infrastructure.Extensions;
using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KMaSA.Infrastructure.Repositories;

/// <summary>
/// Manages blog articles in database storage.
/// </summary>
public class BlogArticlesRepository : IBlogArticlesRepository
{
    private readonly KmasaContext dbContext;
    private readonly IMapper autoMapper;

    /// <summary>
    /// Initializes a new instance of <see cref="BlogArticlesRepository"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    /// <param name="autoMapper">Mapper for mapping blog article's ef entity into dto and vice versa.</param>
    /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
    public BlogArticlesRepository(KmasaContext dbContext, IMapper autoMapper)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<BlogArticleDto>> GetAsync(int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of articles must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.Blogs
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<BlogArticleDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<BlogArticleEntity>, IEnumerable<BlogArticleDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the blog article's id is less than zero.</exception>
    public async Task<BlogArticleDto> GetByIdAsync(int id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Article's identifier must be positive.");
        }

        var entity = await this.dbContext.CourseWorks
            .SingleOrDefaultAsync(ba => ba.Id == id);

        return this.autoMapper.Map<BlogArticleDto>(entity);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    public async Task<int> AddAsync(BlogArticleDto blogArticleDto)
    {
        if (blogArticleDto is null)
        {
            throw new ArgumentNullException(nameof(blogArticleDto));
        }

        var entity = this.autoMapper.Map<BlogArticleEntity>(blogArticleDto);
        await this.dbContext.Blogs.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the blog article's id is less than zero.</exception>
    public async Task<bool> UpdateAsync(int blogArticleId, BlogArticleDto blogArticleDto)
    {
        if (blogArticleId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(blogArticleId), "Article's identifier must be positive.");
        }

        if (blogArticleDto is null)
        {
            throw new ArgumentNullException(nameof(blogArticleDto));
        }

        var entity = await this.dbContext.Blogs
            .SingleOrDefaultAsync(ba => ba.Id == blogArticleId);

        if (entity is null)
        {
            return false;
        }

        entity.Title = blogArticleDto.Title;
        entity.Content = blogArticleDto.Content;

        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the blog article's id is less than zero.</exception>
    public async Task<bool> DeleteAsync(int blogArticleId)
    {
        if (blogArticleId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(blogArticleId), "Article's identifier must be positive.");
        }

        var article = await this.dbContext.CourseWorks
            .SingleOrDefaultAsync(cw => cw.Id == blogArticleId);

        if (article is null)
        {
            return false;
        }

        this.dbContext.CourseWorks.Remove(article);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the blog article's id is less than zero.</exception>
    /// <exception cref="ArgumentException">Throws, picture link is null or empty or whitespace.</exception>
    public async Task<bool> UpdatePicture(int blogArticleId, string pictureLink)
    {
        if (blogArticleId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(blogArticleId), "Article's identifier must be positive.");
        }

        if (string.IsNullOrWhiteSpace(pictureLink))
        {
            throw new ArgumentException("Picture link is null or empty or whitespace.");
        }

        var entity = await this.dbContext.Blogs
            .SingleOrDefaultAsync(ba => ba.Id == blogArticleId);

        if (entity is null)
        {
            return false;
        }

        entity.PicturesLinks = pictureLink;

        await this.dbContext.SaveChangesAsync();

        return true;
    }
}