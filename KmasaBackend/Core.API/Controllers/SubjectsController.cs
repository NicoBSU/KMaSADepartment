using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {

        /// <summary>
        /// Get All sbujects
        /// </summary>
        [HttpGet("allSubjects")]
        public async Task<ActionResult> GetAllSubjects(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get subject by id
        /// </summary>
        [HttpGet("subject/{id}")]
        public async Task<ActionResult> GetSubjectById(int currentPage, int pageSize)
        {
            return Ok();
        }


        /// <summary>
        /// Add new subject
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddSubject(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Add mentor to subject
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/addMentor/{mentorId}")]
        public async Task<ActionResult> UpdateSubjectAddMentor(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update subject
        /// </summary>
        [HttpPut("updateSubject/{id}")]
        public async Task<ActionResult> UpdateSubject(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Remove recommended study resourse
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/removeStudyResource/{studyResourseId}")]
        public async Task<ActionResult> RemoveRecommendedStudyResource(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Remove mentor
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/removeMentor/{mentorId}")]
        public async Task<ActionResult> RemoveMentorFromSubject(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update picture
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/updatePicture")]
        public async Task<ActionResult> UpdatePicture(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Delete subject
        /// </summary>
        [HttpDelete("deleteSubject/{id}")]
        public async Task<ActionResult> Delete(int currentPage, int pageSize)
        {
            return Ok();
        }
    }
}
