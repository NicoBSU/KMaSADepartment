using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.StudyResources;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for study resources storage managing.
/// </summary>
public interface IStudyResourcesRepository
{
    /// <summary>
    /// Gets study resources with specified count.
    /// </summary>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of study resources.</returns>
    Task<PagedModel<GetStudyResourceDto>> GetAsync(int page, int limit);

    /// <summary>
    /// Gets study resources with specified count by author.
    /// </summary>
    /// <param name="mentorId">Id of the author.</param>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of study resources.</returns>
    Task<PagedModel<GetStudyResourceDto>> GetByMentorAsync(int mentorId, int page, int limit);

    /// <summary>
    /// Gets study resources with specified count by subject.
    /// </summary>
    /// <param name="subjectId">Id of the subject.</param>
    /// <param name="page">Page number.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of study resources.</returns>
    Task<PagedModel<GetStudyResourceDto>> GetBySubjectAsync(int subjectId, int page, int limit);

    /// <summary>
    /// Gets study resource by id.
    /// </summary>
    /// <param name="id">Study resource id.</param>
    /// <returns>Study resource with specified id.</returns>
    Task<GetStudyResourceDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new study resource.
    /// </summary>
    /// <param name="studyResourceDto">New study resource.</param>
    /// <returns>Id of the added study resource.</returns>
    Task<int> AddAsync(AddStudyResourceDto studyResourceDto);

    /// <summary>
    /// Updates study resource.
    /// </summary>
    /// <param name="studyResourceId">Study resource id.</param>
    /// <param name="studyResourceDto">New values.</param>
    /// <returns>True, if study resource was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int studyResourceId, AddStudyResourceDto studyResourceDto);

    /// <summary>
    /// Removes study resource.
    /// </summary>
    /// <param name="studyResourceId">Study resource id.</param>
    /// <returns>True, if the study resource was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int studyResourceId);

    /// <summary>
    /// Removes author.
    /// </summary>
    /// <param name="studyResourceId">Study resource id.</param>
    /// <param name="authorId">Resource author.</param>
    /// <returns>True, if the resource author was removed, otherwise, false.</returns>
    Task<bool> RemoveAuthor(int studyResourceId, int authorId);
}