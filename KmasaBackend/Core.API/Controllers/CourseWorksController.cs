using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models.DTO.CourseWorks;
using KMaSA.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseWorksController : ControllerBase
    {
        private readonly ICourseWorksService _courseWorksService;
        private readonly IMapper _mapper;

        public CourseWorksController(ICourseWorksService courseWorksService,
            IMapper mapper)
        {
            _courseWorksService = courseWorksService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All CourseWorks
        /// </summary>
        [HttpGet("allCourseWorks")]
        public async Task<ActionResult> GetAllCourseWorks(int currentPage, int pageSize)
        {
            var result = await _courseWorksService.GetAllCourseWorks(currentPage, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Get course works by mentor
        /// </summary>
        [HttpGet("courseworks/mentor/{mentorId}")]
        public async Task<ActionResult> GetCourseWorksByMentor(int currentPage, int pageSize, int mentorId)
        {
            var result = await _courseWorksService.GetCourseWorksByMentor(mentorId, currentPage, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Get course works by title
        /// </summary>
        [HttpGet("courseworks/title/{title}")]
        public async Task<ActionResult> GetCourseWorksByTitle(int currentPage, int pageSize, string title)
        {
            var result = await _courseWorksService.GetCourseWorksByTitle(currentPage, pageSize, title);
            return Ok(result);
        }

        /// <summary>
        /// Get course works by status
        /// </summary>
        [HttpGet("courseworks/status/{status}")]
        public async Task<ActionResult> GetCourseWorksByStatus(int currentPage, int pageSize, CourseWorkStatus status)
        {
            var result = await _courseWorksService.GetCourseWorksByStatus(currentPage, pageSize, status);
            return Ok(result);
        }

        /// <summary>
        /// Get course work by id
        /// </summary>
        [HttpGet("coursework/{id}")]
        public async Task<ActionResult> GetCourseWorkById(int id)
        {
            var result = await _courseWorksService.GetCourseWorkById(id);
            return Ok(result);
        }

        /// <summary>
        /// Add new coursework
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddCourseWork(AddCourseWorkDto dto)
        {
            var id = await _courseWorksService.AddCourseWork(dto);
            if (id == 0) return BadRequest("Failed to add coursework");
            return Ok(id);
        }

        /// <summary>
        /// Update Course Work
        /// </summary>
        [HttpPut("updateCourseWork/{id}")]
        public async Task<ActionResult> UpdateCourseWork(AddCourseWorkDto dto, int id)
        {
            var result = await _courseWorksService.UpdateCourseWork(dto, id);
            if (result) return Ok();
            return BadRequest("Failed to update coursework");
        }

        /// <summary>
        /// Update Course Work status
        /// </summary>
        [HttpPut("updateCourseWork/{id}/status")]
        public async Task<ActionResult> UpdateCourseWorkStatus(int id, CourseWorkStatus status)
        {
            var result = await _courseWorksService.UpdateCourseWorkStatus(status, id);
            if (result) return Ok();
            return BadRequest("Failed to update coursework status");
        }

        /// <summary>
        /// delete course work
        /// </summary>
        [HttpDelete("deleteCourseWork/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _courseWorksService.DeleteCourseWork(id);
            if (result) return Ok();
            return BadRequest("Failed to delete coursework status");
        }

        /// <summary>
        /// bind student to coursework
        /// </summary>
        [HttpPut("updateCourseWork/{id}/bindStudent/{studentId}")]
        public async Task<ActionResult> BindStudent(int id, int studentId)
        {
            var result = await _courseWorksService.BindStudent(studentId, id);
            if (result) return Ok();
            return BadRequest("Failed to delete coursework status");
        }

        /// <summary>
        /// unbind student from coursework
        /// </summary>
        [HttpPut("unbindStudent/{id}")]
        public async Task<ActionResult> UnbindStudent(int currentPage, int pageSize)
        {
            return Ok();
        }
    }
}
