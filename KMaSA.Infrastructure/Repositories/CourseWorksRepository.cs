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
/// Manages course works in database storage.
/// </summary>
public class CourseWorksRepository : ICourseWorksRepository
{
    private readonly KmasaContext dbContext;
    private readonly IMapper autoMapper;

    /// <summary>
    /// Initializes a new instance of <see cref="CourseWorksRepository"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    /// <param name="autoMapper">Mapper for mapping course work's ef entity into dto and vice versa.</param>
    /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
    public CourseWorksRepository(KmasaContext dbContext, IMapper autoMapper)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<CourseWorkDto>> GetAsync(int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of course works must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.CourseWorks
            .Include(cw => cw.Status)
            .Include(cw => cw.Mentor)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<CourseWorkDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<CourseWorkEntity>, IEnumerable<CourseWorkDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if the limit is less than zero or mentor's id is negative or zero.
    /// </exception>
    public async Task<PagedModel<CourseWorkDto>> GetByMentorAsync(int mentorId, int page, int limit)
    {
        if (mentorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mentorId), "Mentor's id must be positive.");
        }

        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of course works must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.CourseWorks
            .Include(cw => cw.Status)
            .Include(cw => cw.Mentor)
            .Where(cw => cw.Mentor.Id == mentorId)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<CourseWorkDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<CourseWorkEntity>, IEnumerable<CourseWorkDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    /// <exception cref="ArgumentException">Throws, if the title is null or empty or whitespace.</exception>
    public async Task<PagedModel<CourseWorkDto>> GetByTitleAsync(string title, int page, int limit)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is null or empty or whitespace.", nameof(title));
        }

        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of course works must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.CourseWorks
            .Include(cw => cw.Status)
            .Include(cw => cw.Mentor)
            .Where(cw => cw.Title == title)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<CourseWorkDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<CourseWorkEntity>, IEnumerable<CourseWorkDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<CourseWorkDto>> GetByStatusAsync(CourseWorkStatusDto status, int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of course works must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.CourseWorks
            .Include(cw => cw.Status)
            .Include(cw => cw.Mentor)
            .Where(cw => cw.Status == (CourseWorkStatusEntity)(int)status)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<CourseWorkDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<CourseWorkEntity>, IEnumerable<CourseWorkDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the course work's id is less than zero.</exception>
    public async Task<CourseWorkDto> GetByIdAsync(int id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Course work's identifier must be positive.");
        }

        var entity = await this.dbContext.CourseWorks
            .Include(cw => cw.Status)
            .Include(cw => cw.Mentor)
            .Include(cw => cw.Student)
            .SingleOrDefaultAsync(cw => cw.Id == id);

        return this.autoMapper.Map<CourseWorkDto>(entity);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    public async Task<int> AddAsync(CourseWorkDto courseWorkDto)
    {
        if (courseWorkDto is null)
        {
            throw new ArgumentNullException(nameof(courseWorkDto));
        }

        var entity = this.autoMapper.Map<CourseWorkEntity>(courseWorkDto);
        await this.dbContext.CourseWorks.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the course work's id is less than zero.</exception>
    public async Task<bool> UpdateAsync(int courseWorkId, CourseWorkDto courseWorkDto)
    {
        if (courseWorkId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(courseWorkId), "Course work's identifier must be positive.");
        }

        if (courseWorkDto is null)
        {
            throw new ArgumentNullException(nameof(courseWorkDto));
        }

        var entity = await this.dbContext.CourseWorks
            .SingleOrDefaultAsync(cw => cw.Id == courseWorkId);

        if (entity is null)
        {
            return false;
        }

        entity.Title = courseWorkDto.Title;
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the course work's id is less than zero.</exception>
    public async Task<bool> UpdateStatusAsync(int courseWorkId, CourseWorkStatusDto courseWorkStatusDto)
    {
        if (courseWorkId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(courseWorkId), "Course work's identifier must be positive.");
        }

        var entity = await this.dbContext.CourseWorks
            .Include(cw => cw.Status)
            .SingleOrDefaultAsync(cw => cw.Id == courseWorkId);

        if (entity is null)
        {
            return false;
        }

        entity.Status = (CourseWorkStatusEntity)(int)courseWorkStatusDto;
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the course work's id is less than zero.</exception>
    public async Task<bool> DeleteAsync(int courseWorkId)
    {
        if (courseWorkId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(courseWorkId), "Course work's identifier must be positive.");
        }

        var courseWork = await this.dbContext.CourseWorks
            .SingleOrDefaultAsync(cw => cw.Id == courseWorkId);

        if (courseWork is null)
        {
            return false;
        }

        this.dbContext.CourseWorks.Remove(courseWork);
        await this.dbContext.SaveChangesAsync();

        return true;
    }
}