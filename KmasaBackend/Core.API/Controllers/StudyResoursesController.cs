using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models.DTO.StudyResources;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyResourcesController : ControllerBase
    {
        private readonly IStudyResourcesService _studyResourceService;
        private readonly IMapper _mapper;

        public StudyResourcesController(IStudyResourcesService studyResourceService,
            IMapper mapper)
        {
            _studyResourceService = studyResourceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All study resources
        /// </summary>
        [HttpGet("allStudyResources")]
        public async Task<ActionResult> GetAllStudyResources(int currentPage, int pageSize)
        {
            var result = await _studyResourceService.GetAllStudyResources(currentPage, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Get study resources by mentor id
        /// </summary>
        [HttpGet("studyResources/byMentor/{mentorId}")]
        public async Task<ActionResult> GetStudyResourcesByMentor(int currentPage, int pageSize, int mentorId)
        {
            var result = await _studyResourceService.GetStudyResourcesByMentor(currentPage, pageSize, mentorId);
            return Ok(result);
        }

        /// <summary>
        /// Get study resources by subject
        /// </summary>
        [HttpGet("studyResources/bySubject/{subjectId}")]
        public async Task<ActionResult> GetStudyResourcesBySubject(int currentPage, int pageSize, int subjectId)
        {
            var result = await _studyResourceService.GetStudyResourcesBySubject(currentPage, pageSize, subjectId);
            return Ok(result);
        }

        /// <summary>
        /// Get study resource by id
        /// </summary>
        [HttpGet("studyResource/{id}")]
        public async Task<ActionResult> GetStudyResourceById(int id)
        {
            var result = await _studyResourceService.GetStudyResourceById(id);
            return Ok(result);
        }

        /// <summary>
        /// Add new study resource
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddStudyResource(AddStudyResourceDto dto)
        {
            var result = await _studyResourceService.AddStudyResource(dto);
            if (result == 0) return BadRequest("Failed to add study resource");
            return Ok();
        }

        /// <summary>
        /// Update study resource
        /// </summary>
        [HttpPut("updateStudyResource/{id}")]
        public async Task<ActionResult> UpdateStudyResource(AddStudyResourceDto dto, int id)
        {
            var result = await _studyResourceService.UpdateStudyResource(dto, id);
            if (result) return Ok();
            return BadRequest("Failed to update study resource");
        }

        /// <summary>
        /// Remove author from study resource
        /// </summary>
        [HttpPut("updateStudyResource/{studyResourceId}/removeAuthor/{authorId}")]
        public async Task<ActionResult> RemoveStudyResourceAuthor(int studyResourceId, int authorId)
        {
            var result = await _studyResourceService.RemoveStudyResourceAuthor(studyResourceId, authorId);
            if (result) return Ok();
            return BadRequest("Failed to update study resource");
        }

        /// <summary>
        /// delete study resource
        /// </summary>
        [HttpDelete("deleteStudyResource/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _studyResourceService.DeleteStudyResource(id);
            if (result) return Ok();
            return BadRequest("Failed to delete study resource");
        }
    }
}
