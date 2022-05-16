using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyResourcesController : ControllerBase
    {

        /// <summary>
        /// Get All study resources
        /// </summary>
        [HttpGet("allStudyResources")]
        public async Task<ActionResult> GetAllStudyResources(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get study resources by mentor id
        /// </summary>
        [HttpGet("studyResources/byMentor/{mentorId}")]
        public async Task<ActionResult> GetStudyResourcesByMentor(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get study resources by subject
        /// </summary>
        [HttpGet("studyResources/bySubject/{subjectId}")]
        public async Task<ActionResult> GetStudyResourcesBySubject(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get study resource by id
        /// </summary>
        [HttpGet("studyResource/{id}")]
        public async Task<ActionResult> GetStudyResourceById(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Add new study resource
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddStudyResource(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update study resource
        /// </summary>
        [HttpPut("updateStudyResource/{id}")]
        public async Task<ActionResult> UpdateStudyResource(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Remove author from study resource
        /// </summary>
        [HttpPut("updateStudyResource/{studyResourceId}/removeAuthor/{authorId}")]
        public async Task<ActionResult> RemoveStudyResourceAuthor(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// delete study resource
        /// </summary>
        [HttpDelete("deleteStudyResource/{id}")]
        public async Task<ActionResult> Delete(int currentPage, int pageSize)
        {
            return Ok();
        }
    }
}
