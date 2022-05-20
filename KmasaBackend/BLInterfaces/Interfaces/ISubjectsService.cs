using KMaSA.Models;
using KMaSA.Models.DTO.Subjects;

namespace BLInterfaces.Interfaces
{
    public interface ISubjectsService
    {
        Task<PagedModel<GetSubjectDto>> GetAllSubjects(int currentPage, int pageSize);
        Task<GetSubjectDto> GetSubjectById(int id);
        Task<int> AddSubject(AddSubjectDto dto);
        Task<bool> AddMentorToSubject(int subjectId, int mentorId);
        Task<bool> UpdateSubject(int subjectId, AddSubjectDto dto);
        Task<bool> RemoveRecommendedStudyResource(int subjectId, int studyResourceId);
        Task<bool> RemoveMentorFromSubject(int subjectId, int mentorId);
        Task<bool> DeleteSubject(int id);
    }
}
