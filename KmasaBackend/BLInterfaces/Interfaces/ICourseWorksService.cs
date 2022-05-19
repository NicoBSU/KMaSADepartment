using KMaSA.Models;
using KMaSA.Models.DTO.CourseWorks;

namespace BLInterfaces.Interfaces
{
    public interface ICourseWorksService
    {
        Task<PagedModel<GetCourseWorkDto>> GetAllCourseWorks(int currentPage, int pageSize);
    }
}
