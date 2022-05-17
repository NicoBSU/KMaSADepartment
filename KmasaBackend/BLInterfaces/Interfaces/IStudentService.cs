using KMaSA.Models;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.Students;

namespace BLInterfaces.Interfaces
{
    public interface IStudentService
    {
        Task<int> AddStudent(AddStudentDto dto, int userId);

        Task<PagedModel<GetStudentDto>> GetAllStudents(int currentPage, int pageSize);

        Task<PagedModel<GetStudentDto>> GetStudentsByCourse(int currentPage, int pageSize, int courseId);

        Task<GetStudentDto> GetStudentById(int studentId);

        Task<bool> UpdateStudent(int studentId, UpdateStudentDto userDto);
    }
}
