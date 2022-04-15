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
/// Manages MMF subjects in database storage.
/// </summary>
public class SubjectsRepository : ISubjectsRepository
{
    private readonly KmasaContext dbContext;
    private readonly IMapper autoMapper;

    /// <summary>
    /// Initializes a new instance of <see cref="SubjectsRepository"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    /// <param name="autoMapper">Mapper for mapping subject's ef entity into dto and vice versa.</param>
    /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
    public SubjectsRepository(KmasaContext dbContext, IMapper autoMapper)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
    }

    /// <inheritdoc/>
    public async Task<PagedModel<SubjectDto>> GetAsync(int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of subjects must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.Subjects
            .Include(s => s.Mentors)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<SubjectDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<SubjectEntity>, IEnumerable<SubjectDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    public async Task<SubjectDto> GetByIdAsync(int id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Subject's identifier must be positive.");
        }

        var entity = await this.dbContext.Subjects
            .Include(s => s.Mentors)
            .Include(s => s.Literature)
            .SingleOrDefaultAsync(s => s.Id == id);

        return this.autoMapper.Map<SubjectDto>(entity);
    }

    /// <inheritdoc/>
    public async Task<int> AddAsync(SubjectDto subjectDto)
    {
        if (subjectDto is null)
        {
            throw new ArgumentNullException(nameof(subjectDto));
        }

        var entity = this.autoMapper.Map<SubjectEntity>(subjectDto);
        await this.dbContext.Subjects.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task<bool> AddMentor(int subjectId, int mentorId)
    {
        if (subjectId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(subjectId), "Subject's identifier must be positive.");
        }

        if (mentorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mentorId), "Mentor's identifier must be positive.");
        }

        var subject = await this.dbContext.Subjects
            .SingleOrDefaultAsync(s => s.Id == subjectId);
        var mentor = await this.dbContext.Mentors.SingleOrDefaultAsync(m => m.Id == mentorId);

        if (subject is null || mentor is null)
        {
            return false;
        }

        subject.Mentors.Add(mentor);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(int subjectId, SubjectDto subjectDto)
    {
        if (subjectId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(subjectId), "Subject's identifier must be positive.");
        }

        if (subjectDto is null)
        {
            throw new ArgumentNullException(nameof(subjectDto));
        }

        var entity = await this.dbContext.Subjects
            .SingleOrDefaultAsync(s => s.Id == subjectId);

        if (entity is null)
        {
            return false;
        }

        entity.Title = subjectDto.Title;
        entity.Description = subjectDto.Description;
        entity.PictureLink = entity.PictureLink;
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(int subjectId)
    {
        if (subjectId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(subjectId), "Subject's identifier must be positive.");
        }

        var subject = await this.dbContext.Subjects
            .SingleOrDefaultAsync(s => s.Id == subjectId);

        if (subject is null)
        {
            return false;
        }

        this.dbContext.Subjects.Remove(subject);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> RemoveRecommendedStudyResource(int subjectId, int studyResourceId)
    {
        if (subjectId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(subjectId), "Subject's identifier must be positive.");
        }

        if (studyResourceId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(studyResourceId), "Mentor's identifier must be positive.");
        }

        var subject = await this.dbContext.Subjects
            .SingleOrDefaultAsync(s => s.Id == subjectId);
        var resource = await this.dbContext.StudyResources.SingleOrDefaultAsync(m => m.Id == studyResourceId);

        if (subject is null || resource is null)
        {
            return false;
        }

        subject.Literature.Add(resource);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    public async Task<bool> RemoveMentor(int subjectId, int mentorId)
    {
        if (subjectId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(subjectId), "Subject's identifier must be positive.");
        }

        if (mentorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mentorId), "Mentor's identifier must be positive.");
        }

        var subject = await this.dbContext.Subjects
            .SingleOrDefaultAsync(s => s.Id == subjectId);
        var mentor = await this.dbContext.Mentors.SingleOrDefaultAsync(m => m.Id == mentorId);

        if (subject is null || mentor is null)
        {
            return false;
        }

        subject.Mentors.Remove(mentor);
        await this.dbContext.SaveChangesAsync();

        return true;
    }
}