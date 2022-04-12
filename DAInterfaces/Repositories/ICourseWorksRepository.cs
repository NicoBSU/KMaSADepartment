using KMaSA.Models;
using KMaSA.Models.DTO;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for course works storage managing.
/// </summary>
public interface ICourseWorksRepository
{
    /// <summary>
    /// Gets course works with specified count.
    /// </summary>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<CourseWorkDto>> GetAsync(int offset, int limit);

    /// <summary>
    /// Gets course works by mentor.
    /// </summary>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <param name="mentorId">Mentor's id.</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<CourseWorkDto>> GetByMentorAsync(int mentorId, int offset, int limit);

    /// <summary>
    /// Gets course works by title.
    /// </summary>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <param name="title">Course work title.</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<CourseWorkDto>> GetByTitleAsync(string title, int offset, int limit);

    /// <summary>
    /// Gets course works with specified status.
    /// </summary>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <param name="status">Course work status.</param>
    /// <returns>Paged model with collection of blog articles.</returns>
    Task<PagedModel<CourseWorkDto>> GetByStatusAsync(CourseWorkStatusDto status, int offset, int limit);

    /// <summary>
    /// Gets course work by id.
    /// </summary>
    /// <param name="id">Course work id.</param>
    /// <returns>Course work with specified id.</returns>
    Task<CourseWorkDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new course work.
    /// </summary>
    /// <param name="courseWorkDto">New course work.</param>
    /// <returns>Id of created course work.</returns>
    Task<int> AddAsync(CourseWorkDto courseWorkDto);

    /// <summary>
    /// Updates course work.
    /// </summary>
    /// <param name="courseWorkId">Id of the course work.</param>
    /// <param name="courseWorkDto">New values.</param>
    /// <returns>True, if course work was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int courseWorkId, CourseWorkDto courseWorkDto);

    /// <summary>
    /// Removes course work.
    /// </summary>
    /// <param name="courseWorkId">Id of the course work.</param>
    /// <returns>True, if course work was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int courseWorkId);
}