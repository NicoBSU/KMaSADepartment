using KMaSA.Models;
using KMaSA.Models.DTO.StudyResources;

namespace BLInterfaces.Interfaces
{
    public interface IStudyResourcesService
    {
        Task<PagedModel<GetStudyResourceDto>> GetAllStudyResources(int currentPage, int pageSize);
        Task<PagedModel<GetStudyResourceDto>> GetStudyResourcesByMentor(int currentPage, int pageSize, int mentorId);
        Task<PagedModel<GetStudyResourceDto>> GetStudyResourcesBySubject(int currentPage, int pageSize, int subjectId);
        Task<GetStudyResourceDto> GetStudyResourceById(int id);
        Task<int> AddStudyResource(AddStudyResourceDto dto);
        Task<bool> UpdateStudyResource(AddStudyResourceDto dto, int id);
        Task<bool> RemoveStudyResourceAuthor(int studyResourceId, int authorId);
        Task<bool> DeleteStudyResource(int id);
    }
}
