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
    /// Adds mentor for subject.
    /// </summary>
    /// <param name="subjectId">Id of the subject.</param>
    /// <param name="mentorId">Id of the mentor.</param>
    /// <returns>True, if mentor was added, otherwise, false.</returns>
    Task<bool> AddMentor(int subjectId, int mentorId);

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

    /// <summary>
    /// Removes recommended study resource for subject.
    /// </summary>
    /// <param name="subjectId">Id of the subject.</param>
    /// <param name="studyResourceId">Id of the recommended resource.</param>
    /// <returns>True, if study resource was deleted, otherwise, false.</returns>
    Task<bool> RemoveRecommendedStudyResource(int subjectId, int studyResourceId);

    /// <summary>
    /// Removes mentor for subject.
    /// </summary>
    /// <param name="subjectId">Id of the subject.</param>
    /// <param name="mentorId">Id of the mentor.</param>
    /// <returns>True, if mentor was deleted, otherwise, false.</returns>
    Task<bool> RemoveMentor(int subjectId, int mentorId);

    /// <summary>
    /// Updates subject's picture.
    /// </summary>
    /// <param name="subjectId">Id of the subject</param>
    /// <param name="pictureLink">Link to picture storage.</param>
    /// <returns>True, if the link was updated, otherwise, false</returns>
    Task<bool> UpdatePicture(int subjectId, string pictureLink);
}