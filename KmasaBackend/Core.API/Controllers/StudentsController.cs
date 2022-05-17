using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.Students;
using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentsService;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentsService,
            UserManager<UserEntity> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _studentsService = studentsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All students
        /// </summary>
        [HttpGet("allStudents")]
        public async Task<ActionResult<PagedModel<GetStudentDto>>> GetAllStudents(int currentPage, int pageSize)
        {
            var studentsList = await _studentsService.GetAllStudents(currentPage,pageSize);
            foreach (var item in studentsList.Items)
            {
                var userEntity = await _userManager.FindByIdAsync(item.UserId.ToString());
                item.User = _mapper.Map<UserDto>(userEntity);
            }
            return studentsList;
        }

        /// <summary>
        /// Get Students with same course
        /// </summary>
        [HttpGet("students/{courseId}")]
        public async Task<ActionResult<PagedModel<GetStudentDto>>> GetStudentsByCourse(int currentPage, int pageSize, int courseId)
        {
            var studentsList = await _studentsService.GetStudentsByCourse(currentPage, pageSize, courseId);
            foreach (var item in studentsList.Items)
            {
                var userEntity = await _userManager.FindByIdAsync(item.UserId.ToString());
                item.User = _mapper.Map<UserDto>(userEntity);
            }
            return studentsList;
        }

        /// <summary>
        /// Get student by id
        /// </summary>
        [HttpGet("student/{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudentById(int id)
        {
            var student = await _studentsService.GetStudentById(id);
            var userEntity = await _userManager.FindByIdAsync(student.UserId.ToString());
            student.User = _mapper.Map<UserDto>(userEntity);

            return student;
        }

        /// <summary>
        /// Update Student
        /// </summary>
        [HttpPut("updateStudent/{id}")]
        public async Task<ActionResult<GetStudentDto>> UpdateStudent(int id, UpdateStudentDto dto)
        {
            var result = await _studentsService.UpdateStudent(id, dto);
            if (result) return Ok();
            return BadRequest("Failed to update user");
        }
    }
}
