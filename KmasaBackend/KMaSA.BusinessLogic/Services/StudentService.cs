using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;

namespace KMaSA.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;
        public StudentService(IStudentsRepository studentsRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _studentsRepository = studentsRepository;
        }

        public async Task<int> AddStudent(AddStudentDto dto, int userId)
        {
            dto.UserId = userId;
            var studentId = await _studentsRepository.AddAsync(dto);
            return studentId;
        }
    }
}
