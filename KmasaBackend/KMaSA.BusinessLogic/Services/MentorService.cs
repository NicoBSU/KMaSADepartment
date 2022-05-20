using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.Mentors;

namespace KMaSA.BusinessLogic.Services
{
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly IMentorsRepository _mentorsRepository;
        public MentorService(IMentorsRepository mentorsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _mentorsRepository = mentorsRepository;
        }

        public async Task<int> AddMentor(AddMentorDto dto, int userId)
        {
            dto.UserId = userId;
            var mentorId = await _mentorsRepository.AddAsync(dto);
            return mentorId;
        }

        public async Task<PagedModel<GetMentorDto>> GetAllMentors(int currentPage, int pageSize)
        {
            var mentors = await _mentorsRepository.GetAsync(currentPage, pageSize);
            return mentors;
        }

        public async Task<GetMentorDto> GetMentorById(int id)
        {
            var mentor = await _mentorsRepository.GetByIdAsync(id);
            return mentor;
        }

        public async Task<bool> UpdateMentor(int studentId, UpdateMentorDto userDto)
        {
            var mresult = await _mentorsRepository.UpdateAsync(studentId, userDto);
            return mresult;
        }
    }
}
