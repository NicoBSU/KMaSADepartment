using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO.StudyResources;

namespace KMaSA.BusinessLogic.Services
{
    public class StudyResourcesService : IStudyResourcesService
    {
        private readonly IMapper _mapper;
        private readonly IStudyResourcesRepository _studyResourcesRepository;
        public StudyResourcesService(IStudyResourcesRepository studyResourcesRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _studyResourcesRepository = studyResourcesRepository;
        }

        public async Task<PagedModel<GetStudyResourceDto>> GetAllStudyResources(int currentPage, int pageSize)
        {
            var result = await _studyResourcesRepository.GetAsync(currentPage, pageSize);
            return result;
        }

        public async Task<PagedModel<GetStudyResourceDto>> GetStudyResourcesByMentor(int currentPage, int pageSize, int mentorId)
        {
            var result = await _studyResourcesRepository.GetByMentorAsync(mentorId,currentPage, pageSize);
            return result;
        }

        public async Task<PagedModel<GetStudyResourceDto>> GetStudyResourcesBySubject(int currentPage, int pageSize, int subjectId)
        {
            var result = await _studyResourcesRepository.GetBySubjectAsync(subjectId, currentPage, pageSize);
            return result;
        }

        public async Task<GetStudyResourceDto> GetStudyResourceById(int id)
        {
            var result = await _studyResourcesRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<int> AddStudyResource(AddStudyResourceDto dto)
        {
            var id = await _studyResourcesRepository.AddAsync(dto);
            return id;
        }

        public async Task<bool> UpdateStudyResource(AddStudyResourceDto dto, int id)
        {
            var result = await _studyResourcesRepository.UpdateAsync(id, dto);
            return result;
        }

        public async Task<bool> RemoveStudyResourceAuthor(int studyResourceId, int authorId)
        {
            var result = await _studyResourcesRepository.RemoveAuthor(studyResourceId, authorId);
            return result;
        }
        
        public async Task<bool> DeleteStudyResource(int id)
        {
            return await _studyResourcesRepository.DeleteAsync(id);
        }
    }
}
