using AutoMapper;
using DAInterfaces.Repositories;
using KMaSA.Infrastructure.EF;
using KMaSA.Infrastructure.Extensions;
using KMaSA.Models;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.Students;
using KMaSA.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KMaSA.Infrastructure.Repositories;

/// <summary>
/// Manages students in database storage.
/// </summary>
public class StudentsRepository : IStudentsRepository
{
    private readonly KmasaContext dbContext;
    private readonly IMapper autoMapper;

    /// <summary>
    /// Initializes a new instance of <see cref="StudentsRepository"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>
    /// <param name="autoMapper">Mapper for mapping student's ef entity into dto and vice versa.</param>
    /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
    public StudentsRepository(KmasaContext dbContext, IMapper autoMapper)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<GetStudentDto>> GetAsync(int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of students must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.Students
            .Include(s => s.Course)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<GetStudentDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<StudentEntity>, IEnumerable<GetStudentDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
    public async Task<PagedModel<GetStudentDto>> GetByCourseAsync(int courseId, int page, int limit)
    {
        if (limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Count of students must be non-negative.");
        }

        var entityPagedModel = await this.dbContext.Students
            .Include(s => s.Course)
            .Where(s => s.Course.Id == courseId)
            .PaginateAsync(page, limit, new CancellationToken());

        return new PagedModel<GetStudentDto>
        {
            PageSize = entityPagedModel.PageSize,
            CurrentPage = entityPagedModel.CurrentPage,
            TotalCount = entityPagedModel.TotalCount,
            Items = this.autoMapper
                .Map<IEnumerable<StudentEntity>, IEnumerable<GetStudentDto>>(entityPagedModel.Items),
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the student's id is less than zero.</exception>
    public async Task<GetStudentDto> GetByIdAsync(int id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Student's identifier must be positive.");
        }

        var entity = await this.dbContext.Students
            .Include(s => s.Course)
            .Include(s => s.Subjects)
            .Include(s=> s.CourseWork)
            .ThenInclude(cw => (cw as CourseWorkEntity).Status)
            .SingleOrDefaultAsync(m => m.Id == id);

        return this.autoMapper.Map<GetStudentDto>(entity);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    public async Task<int> AddAsync(AddStudentDto studentDto)
    {
        if (studentDto is null)
        {
            throw new ArgumentNullException(nameof(studentDto));
        }

        var entity = this.autoMapper.Map<StudentEntity>(studentDto);
        await this.dbContext.Students.AddAsync(entity);
        await this.dbContext.SaveChangesAsync();

        return entity.Id;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Throws, if the dto is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the student's id is less than zero.</exception>
    public async Task<bool> UpdateAsync(int studentId, UpdateStudentDto studentDto)
    {
        if (studentId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(studentId), "Student's identifier must be positive.");
        }

        if (studentDto is null)
        {
            throw new ArgumentNullException(nameof(studentDto));
        }

        var entity = await this.dbContext.Students
            .SingleOrDefaultAsync(m => m.Id == studentId);

        if (entity is null)
        {
            return false;
        }

        Update(entity, studentDto);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Throws, if the student's id is less than zero.</exception>
    public async Task<bool> DeleteAsync(int studentId)
    {
        if (studentId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(studentId), "Student's identifier must be positive.");
        }

        var student = await this.dbContext.Students.SingleOrDefaultAsync(m => m.Id == studentId);

        if (student is null)
        {
            return false;
        }

        this.dbContext.Students.Remove(student);
        await this.dbContext.SaveChangesAsync();

        return true;
    }

    private void Update(StudentEntity entity, UpdateStudentDto studentDto)
    {
        entity.Rating = studentDto.Rating;
    }
}