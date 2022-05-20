using KMaSA.Models;
using KMaSA.Models.DTO.CourseWorks;
using KMaSA.Models.Enums;

namespace BLInterfaces.Interfaces
{
    public interface ICourseWorksService
    {
        Task<PagedModel<GetCourseWorkDto>> GetAllCourseWorks(int currentPage, int pageSize);
        Task<PagedModel<GetCourseWorkDto>> GetCourseWorksByMentor(int currentPage, int pageSize, int mentorId);
        Task<PagedModel<GetCourseWorkDto>> GetCourseWorksByTitle(int currentPage, int pageSize, string title);
        Task<PagedModel<GetCourseWorkDto>> GetCourseWorksByStatus(int currentPage, int pageSize, CourseWorkStatus status);
        Task<GetCourseWorkDto> GetCourseWorkById(int id);
        Task<int> AddCourseWork(AddCourseWorkDto dto);
        Task<bool> UpdateCourseWork(AddCourseWorkDto dto, int id);
        Task<bool> UpdateCourseWorkStatus(CourseWorkStatus status, int id);
        Task<bool> DeleteCourseWork(int id);
        Task<bool> BindStudent(int studentId, int courseWorkId);
        Task<bool> UnbindStudent(int courseWorkId);
    }
}
