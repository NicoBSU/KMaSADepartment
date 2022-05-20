using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO.Subjects;

namespace KMaSA.BusinessLogic.Services
{
    public class SubjectsService : ISubjectsService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _subjectsRepository = subjectsRepository;
        }

        public async Task<PagedModel<GetSubjectDto>> GetAllSubjects(int currentPage, int pageSize)
        {
            var result = await _subjectsRepository.GetAsync(currentPage, pageSize);
            return result;
        }

        public async Task<GetSubjectDto> GetSubjectById(int id)
        {
            var result = await _subjectsRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<int> AddSubject(AddSubjectDto dto)
        {
            var result = await _subjectsRepository.AddAsync(dto);
            return result;
        }

        public async Task<bool> AddMentorToSubject(int subjectId, int mentorId)
        {
            var result = await _subjectsRepository.AddMentor(subjectId, mentorId);
            return result;
        }

        public async Task<bool> UpdateSubject(int subjectId, AddSubjectDto dto)
        {
            var result = await _subjectsRepository.UpdateAsync(subjectId, dto);
            return result;
        }

        public async Task<bool> RemoveRecommendedStudyResource(int subjectId, int studyResourceId)
        {
            var result = await _subjectsRepository.RemoveRecommendedStudyResource(subjectId, studyResourceId);
            return result;
        }

        public async Task<bool> RemoveMentorFromSubject(int subjectId, int mentorId)
        {
            var result = await _subjectsRepository.RemoveMentor(subjectId, mentorId);
            return result;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var result = await _subjectsRepository.DeleteAsync(id);
            return result;
        }
    }
}
