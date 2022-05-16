using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {

        /// <summary>
        /// Get All Mentors
        /// </summary>
        [HttpGet("allMentors")]
        public async Task<ActionResult> GetAllMentors(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get mentor by id
        /// </summary>
        [HttpGet("mentor/{id}")]
        public async Task<ActionResult> GetMentorById(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update Mentor
        /// </summary>
        [HttpPut("updateMentor/{id}")]
        public async Task<ActionResult> UpdateMentor(int currentPage, int pageSize)
        {
            return Ok();
        }
    }
}
