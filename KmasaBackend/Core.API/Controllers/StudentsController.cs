using BLInterfaces.Interfaces;
using KMaSA.Models;
using KMaSA.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentsService;
        public StudentsController(IStudentService studentsService)
        {
            _studentsService = studentsService;
        }

        /// <summary>
        /// Get All students
        /// </summary>
        [HttpGet("allStudents")]
        public async Task<ActionResult<PagedModel<GetStudentDto>>> GetAllStudents(int currentPage, int pageSize)
        {
            var studentsList = await _studentsService.GetAllStudents(currentPage,pageSize);

            return studentsList;
        }

        /// <summary>
        /// Get Students with same course
        /// </summary>
        [HttpGet("students/{course}")]
        public async Task<ActionResult<PagedModel<GetStudentDto>>> GetStudentsByCourse(int currentPage, int pageSize)
        {
            var studentsList = await _studentsService.GetAllStudents(currentPage, pageSize);

            return studentsList;
        }

        /// <summary>
        /// Get student by id
        /// </summary>
        [HttpGet("student/{id}")]
        public async Task<ActionResult<PagedModel<GetStudentDto>>> GetStudentById(int currentPage, int pageSize)
        {
            var studentsList = await _studentsService.GetAllStudents(currentPage, pageSize);

            return studentsList;
        }

        /// <summary>
        /// Update Student
        /// </summary>
        [HttpPut("updateStudent/{id}")]
        public async Task<ActionResult<PagedModel<GetStudentDto>>> UpdateStudent(int currentPage, int pageSize)
        {
            var studentsList = await _studentsService.GetAllStudents(currentPage, pageSize);

            return studentsList;
        }
    }
}
