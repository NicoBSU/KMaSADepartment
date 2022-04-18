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
/// Manages study resources in database storage.
/// </summary>
public class StudyResourceRepository : IStudyResourcesRepository
{
    private readonly KmasaContext dbContext;
    private readonly IMapper autoMapper;

    /// <summary>
    /// Initializes a new instance of <see cref="StudyResourceRepository"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    /// <param name="autoMapper">Mapper for mapping study resource's ef entity into dto and vice versa.</param>
    /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
    public StudyResourceRepository(KmasaContext dbContext, IMapper autoMapper)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<StudyResourceDto>> GetAsync(int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of resources must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.StudyResources
            .Include(sr => sr.TaggedMentors)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<StudyResourceDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<StudyResourceEntity>, IEnumerable<StudyResourceDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if the limit is less than zero or mentor's id is negative or zero.
    /// </exception>
    public async Task<PagedModel<StudyResourceDto>> GetByMentorAsync(int mentorId, int page, int limit)
    {
        if (mentorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mentorId), "Mentor's id must be positive.");
        }

        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of resources must be non-negative.");
        }

        var mentor = await this.dbContext.Mentors
            .SingleOrDefaultAsync(m => m.Id == mentorId);

        var entityPagedModel = await this.dbContext.StudyResources
            .Include(sr => sr.TaggedMentors)
            .Where(cr => cr.TaggedMentors.Contains(mentor))
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<StudyResourceDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<StudyResourceEntity>, IEnumerable<StudyResourceDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if the limit is less than zero or subject's id is negative or zero.
    /// </exception>
    public async Task<PagedModel<StudyResourceDto>> GetBySubjectAsync(int subjectId, int page, int limit)
    {
        if (subjectId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(subjectId), "Subject's id must be positive.");
        }

        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of resources must be non-negative.");
        }

        var subject = await this.dbContext.Subjects
            .SingleOrDefaultAsync(s => s.Id == subjectId);

        var entityPagedModel = await this.dbContext.StudyResources
            .Include(sr => sr.Subjects)
            .Include(sr => sr.TaggedMentors)
            .Where(cr => cr.Subjects.Contains(subject))
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<StudyResourceDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<StudyResourceEntity>, IEnumerable<StudyResourceDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the study resource's id is less than zero.</exception>
    public async Task<StudyResourceDto> GetByIdAsync(int id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Mentor identifier must be positive.");
        }

        var entity = await this.dbContext.StudyResources
            .Include(sr => sr.Subjects)
            .Include(sr => sr.TaggedMentors)
            .SingleOrDefaultAsync(sr => sr.Id == id);

        return this.autoMapper.Map<StudyResourceDto>(entity);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    public async Task<int> AddAsync(StudyResourceDto studyResourceDto)
    {
        if (studyResourceDto is null)
        {
            throw new ArgumentNullException(nameof(studyResourceDto));
        }

        var entity = this.autoMapper.Map<StudyResourceEntity>(studyResourceDto);
        await this.dbContext.StudyResources.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the study resource's id is less than zero.</exception>
    public async Task<bool> UpdateAsync(int studyResourceId, StudyResourceDto studyResourceDto)
    {
        if (studyResourceId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(studyResourceId), "Study resource identifier must be positive.");
        }

        if (studyResourceDto is null)
        {
            throw new ArgumentNullException(nameof(studyResourceDto));
        }

        var entity = await this.dbContext.StudyResources
            .SingleOrDefaultAsync(m => m.Id == studyResourceId);

        if (entity is null)
        {
            return false;
        }

        Update(entity, studyResourceDto);
        await this.dbContext.SaveChangesAsync();

        return true; }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the study resource's id is less than zero.</exception>
    public async Task<bool> DeleteAsync(int studyResourceId)
    {
        if (studyResourceId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(studyResourceId), "Mentor identifier must be positive.");
        }

        var studyResource = await this.dbContext.StudyResources
            .SingleOrDefaultAsync(m => m.Id == studyResourceId);

        if (studyResource is null)
        {
            return false;
        }

        this.dbContext.StudyResources.Remove(studyResource);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws, if the study resource's id or mentor's id is less than or equals zero.
    /// </exception>
    public async Task<bool> RemoveAuthor(int studyResourceId, int authorId)
    {
        if (studyResourceId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(studyResourceId), "Study resource id is less than one.");
        }

        if (authorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(authorId), "Author id is less than one.");
        }

        var author = await this.dbContext.Mentors.SingleOrDefaultAsync(m => m.Id == authorId);
        var resource = await this.dbContext.StudyResources
            .Include(sr => sr.TaggedMentors)
            .FirstOrDefaultAsync(sr => sr.Id == studyResourceId);

        if (author is null || resource is null)
        {
            return false;
        }

        resource.TaggedMentors.Remove(author);

        await this.dbContext.SaveChangesAsync();

        return true;
    }

    private static void Update(StudyResourceEntity entity, StudyResourceDto studyResourceDto)
    {
        entity.Name = studyResourceDto.Name;
        entity.Link = studyResourceDto.Link;
    }
}