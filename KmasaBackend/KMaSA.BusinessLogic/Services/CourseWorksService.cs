using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO.CourseWorks;

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

    }
}
