using KMaSA.Models.DTO;
using KMaSA.Models.Entities;

namespace BLInterfaces.Interfaces
{
    public interface IStudentService
    {
        Task<int> AddStudent(AddStudentDto dto, int userId);
    }
}
