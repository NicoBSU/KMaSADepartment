using KMaSA.Models;
using KMaSA.Models.DTO;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for subjects storage managing.
/// </summary>
public interface ISubjectsRepository
{
    /// <summary>
    /// Gets subjects with specified count.
    /// </summary>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of subjects.</returns>
    Task<PagedModel<SubjectDto>> GetAsync(int page, int limit);

    /// <summary>
    /// Gets subject by id.
    /// </summary>
    /// <param name="id">Subject's id.</param>
    /// <returns>Subject with specified id.</returns>
    Task<SubjectDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new subject.
    /// </summary>
    /// <param name="subjectDto">New subject.</param>
    /// <returns>Id of created subject.</returns>
    Task<int> AddAsync(SubjectDto subjectDto);

    /// <summary>
    /// Updates subject.
    /// </summary>
    /// <param name="subjectId">Id of the subject.</param>
    /// <param name="subjectDto">New values.</param>
    /// <returns>True, if subject was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int subjectId, SubjectDto subjectDto);

    /// <summary>
    /// Removes subject.
    /// </summary>
    /// <param name="subjectId">Id of the subject.</param>
    /// <returns>True, if subject was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int subjectId);
}