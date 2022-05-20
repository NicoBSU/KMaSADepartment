using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO.CourseWorks;
using KMaSA.Models.Enums;

namespace KMaSA.BusinessLogic.Services
{
    public class CourseWorksService : ICourseWorksService
    {
        private readonly IMapper _mapper;
        private readonly ICourseWorksRepository _courseWorksRepository;
        public CourseWorksService(ICourseWorksRepository courseWorksRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _courseWorksRepository = courseWorksRepository;
        }
        public async Task<PagedModel<GetCourseWorkDto>> GetAllCourseWorks(int currentPage, int pageSize)
        {
            var result = await _courseWorksRepository.GetAsync(currentPage, pageSize);
            return result;
        }

        public async Task<PagedModel<GetCourseWorkDto>> GetCourseWorksByMentor(int currentPage, int pageSize, int mentorId)
        {
            var result = await _courseWorksRepository.GetByMentorAsync(mentorId, currentPage, pageSize);
            return result;
        }

        public async Task<PagedModel<GetCourseWorkDto>> GetCourseWorksByTitle(int currentPage, int pageSize, string title)
        {
            var result = await _courseWorksRepository.GetByTitleAsync(title, currentPage, pageSize);
            return result;
        }

        public async Task<PagedModel<GetCourseWorkDto>> GetCourseWorksByStatus(int currentPage, int pageSize, CourseWorkStatus status)
        {
            var result = await _courseWorksRepository.GetByStatusAsync(status, currentPage, pageSize);
            return result;
        }

        public async Task<GetCourseWorkDto> GetCourseWorkById(int id)
        {
            var result = await _courseWorksRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<int> AddCourseWork(AddCourseWorkDto dto)
        {
            var id = await _courseWorksRepository.AddAsync(dto);
            return id;
        }

        public async Task<bool> UpdateCourseWork(AddCourseWorkDto dto, int id)
        {
            var result = await _courseWorksRepository.UpdateAsync(id, dto);
            return result;
        }

        public async Task<bool> UpdateCourseWorkStatus(CourseWorkStatus status, int id)
        {
            var result = await _courseWorksRepository.UpdateStatusAsync(id, status);
            return result;
        }

        public async Task<bool> DeleteCourseWork(int id)
        {
            var result = await _courseWorksRepository.DeleteAsync(id);
            return result;
        }

        public async Task<bool> BindStudent(int studentId, int courseWorkId)
        {
            var result = await _courseWorksRepository.BindStudent(studentId, courseWorkId);
            return result;
        }

        public async Task<bool> UnbindStudent(int courseWorkId)
        {
            var result = await _courseWorksRepository.UnbindStudent(courseWorkId);
            return result;
        }
    }
}
