using KMaSA.Models;
using KMaSA.Models.DTO;

namespace DAInterfaces.Repositories;

/// <summary>
/// Provides methods for students storage managing.
/// </summary>
public interface IStudentsRepository
{
    /// <summary>
    /// Gets students with specified count.
    /// </summary>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of students.</returns>
    Task<PagedModel<StudentDto>> GetAsync(int offset, int limit);

    /// <summary>
    /// Gets students of the certain course.
    /// </summary>
    /// <param name="course">Course.</param>
    /// <param name="offset">Count of items to skip.</param>
    /// <param name="limit">Count of items to take</param>
    /// <returns>Paged model with collection of students.</returns>
    Task<PagedModel<StudentDto>> GetByCourseAsync(CourseDto course, int offset, int limit);

    /// <summary>
    /// Gets student by id.
    /// </summary>
    /// <param name="id">Student's id.</param>
    /// <returns>Student with specified id.</returns>
    Task<StudentDto> GetByIdAsync(int id);

    /// <summary>
    /// Adds new student.
    /// </summary>
    /// <param name="studentDto">New student.</param>
    /// <returns>Id of the added student.</returns>
    Task<int> AddAsync(StudentDto studentDto);

    /// <summary>
    /// Updates student's info.
    /// </summary>
    /// <param name="studentId">Student's id.</param>
    /// <param name="studentDto">New values.</param>
    /// <returns>True, if student's information was updated, otherwise, false.</returns>
    Task<bool> UpdateAsync(int studentId, StudentDto studentDto);

    /// <summary>
    /// Removes student.
    /// </summary>
    /// <param name="studentId">Student's id.</param>
    /// <returns>True, if the student was deleted, otherwise, false.</returns>
    Task<bool> DeleteAsync(int studentId);
}