using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.Students;
using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace KMaSA.BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentsRepository _studentsRepository;
        public StudentService(IStudentsRepository studentsRepository,
            IMapper mapper, UserManager<UserEntity> userManager)
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

        public async Task<PagedModel<GetStudentDto>> GetAllStudents(int currentPage, int pageSize)
        {
            var students = await _studentsRepository.GetAsync(currentPage,pageSize);
            return students;
        }

        public async Task<PagedModel<GetStudentDto>> GetStudentsByCourse(int currentPage, int pageSize, int courseId)
        {
            var students = await _studentsRepository.GetByCourseAsync(courseId, currentPage, pageSize);
            return students;
        }

        public async Task<GetStudentDto> GetStudentById(int studentId)
        {
            var student = await _studentsRepository.GetByIdAsync(studentId);
            return student;
        }

        public async Task<bool> UpdateStudent(int studentId, UpdateStudentDto userDto)
        {
            var result = await _studentsRepository.UpdateAsync(studentId, userDto);
            return result;
        }
    }
}
