using KMaSA.Models;
using KMaSA.Models.DTO;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for mentors storage managing.
/// </summary>
public interface IMentorsRepository
{
    /// <summary>
    /// Gets mentors with specified count.
    /// </summary>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of mentors.</returns>
    Task<PagedModel<MentorDto>> GetAsync(int page, int limit);

    /// <summary>
    /// Gets mentor by id.
    /// </summary>
    /// <param name="id">Mentor's id.</param>
    /// <returns>Mentor with specified id.</returns>
    Task<MentorDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new mentor.
    /// </summary>
    /// <param name="mentorDto">New mentor.</param>
    /// <returns>Id of the added mentor.</returns>
    Task<int> AddAsync(MentorDto mentorDto);

    /// <summary>
    /// Updates mentor's info.
    /// </summary>
    /// <param name="mentorId">Mentor's id.</param>
    /// <param name="mentorDto">New values.</param>
    /// <returns>True, if mentor's information was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int mentorId, MentorDto mentorDto);

    /// <summary>
    /// Removes mentor.
    /// </summary>
    /// <param name="mentorId">Mentor's id.</param>
    /// <returns>True, if the mentor was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int mentorId);
}