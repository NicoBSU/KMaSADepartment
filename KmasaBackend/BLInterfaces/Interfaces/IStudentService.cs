using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.Entities;

namespace BLInterfaces.Interfaces
{
    public interface IStudentService
    {
        Task<int> AddStudent(AddStudentDto dto, int userId);

        Task<PagedModel<GetStudentDto>> GetAllStudents(int currentPage, int pageSize);
    }
}
