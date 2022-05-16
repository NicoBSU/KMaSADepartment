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
/// Manages mentors in database storage.
/// </summary>
public class MentorsRepository : IMentorsRepository
{
    private readonly KmasaContext dbContext;
    private readonly IMapper autoMapper;

    /// <summary>
    /// Initializes a new instance of <see cref="MentorsRepository"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    /// <param name="autoMapper">Mapper for mapping mentor's ef entity into dto and vice versa.</param>
    /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
    public MentorsRepository(KmasaContext dbContext, IMapper autoMapper)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<AddMentorDto>> GetAsync(int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of mentors must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.Mentors
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<AddMentorDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<MentorEntity>, IEnumerable<AddMentorDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the mentor's id is less than zero.</exception>
    public async Task<AddMentorDto> GetByIdAsync(int id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Mentor identifier must be positive.");
        }

        var entity = await this.dbContext.Mentors
            .Include(m => m.Publications)
            .Include(m => m.CourseWorks)
            .ThenInclude(cw => cw.Status)
            .Include(m => m.Subjects)
            .SingleOrDefaultAsync(m => m.Id == id);

        return this.autoMapper.Map<AddMentorDto>(entity);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    public async Task<int> AddAsync(AddMentorDto mentorDto)
    {
        if (mentorDto is null)
        {
            throw new ArgumentNullException(nameof(mentorDto));
        }

        var entity = this.autoMapper.Map<MentorEntity>(mentorDto);
        await this.dbContext.Mentors.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the mentor's id is less than zero.</exception>
    public async Task<bool> UpdateAsync(int mentorId, AddMentorDto mentorDto)
    {
        if (mentorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mentorId), "Mentor identifier must be positive.");
        }

        if (mentorDto is null)
        {
            throw new ArgumentNullException(nameof(mentorDto));
        }

        var entity = await this.dbContext.Mentors
            .SingleOrDefaultAsync(m => m.Id == mentorId);

        if (entity is null)
        {
            return false;
        }

        Update(entity, mentorDto);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the mentor's id is less than zero.</exception>
    public async Task<bool> DeleteAsync(int mentorId)
    {
        if (mentorId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(mentorId), "Mentor identifier must be positive.");
        }

        var mentor = await this.dbContext.Mentors.SingleOrDefaultAsync(m => m.Id == mentorId);

        if (mentor is null)
        {
            return false;
        }

        this.dbContext.Mentors.Remove(mentor);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    private void Update(MentorEntity entity, AddMentorDto dto)
    {
        entity.Biography = dto.Biography;
        entity.Title = dto.Title;
    }
}