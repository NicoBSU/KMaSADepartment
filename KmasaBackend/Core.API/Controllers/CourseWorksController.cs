using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseWorksController : ControllerBase
    {

        /// <summary>
        /// Get All CourseWorks
        /// </summary>
        [HttpGet("allCourseWorks")]
        public async Task<ActionResult> GetAllCourseWorks(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get course works by mentor
        /// </summary>
        [HttpGet("courseworks/mentor/{mentorId}")]
        public async Task<ActionResult> GetCourseWorksByMentor(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get course works by title
        /// </summary>
        [HttpGet("courseworks/title/{title}")]
        public async Task<ActionResult> GetCourseWorksByTitle(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get course works by status
        /// </summary>
        [HttpGet("courseworks/status/{status}")]
        public async Task<ActionResult> GetCourseWorksByStatus(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get course work by id
        /// </summary>
        [HttpGet("coursework/{id}")]
        public async Task<ActionResult> GetCourseWorkById(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Add new coursework
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddCourseWork(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update Course Work
        /// </summary>
        [HttpPut("updateCourseWork/{id}")]
        public async Task<ActionResult> UpdateCourseWork(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update Course Work status
        /// </summary>
        [HttpPut("updateCourseWork/{id}/status")]
        public async Task<ActionResult> UpdateCourseWorkStatus(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// delete course work
        /// </summary>
        [HttpDelete("deleteCourseWork/{id}")]
        public async Task<ActionResult> Delete(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// bind student to coursework
        /// </summary>
        [HttpPut("bindStudent/{studentId}")]
        public async Task<ActionResult> BindStudent(int currentPage, int pageSize)
        {
            return Ok();
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
