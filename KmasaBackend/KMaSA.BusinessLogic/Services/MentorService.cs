using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.Entities;

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
    }
}
