using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models.DTO.Subjects;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsService _subjectsService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectsService subjectsService,
            IMapper mapper)
        {
            _subjectsService = subjectsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All sbujects
        /// </summary>
        [HttpGet("allSubjects")]
        public async Task<ActionResult> GetAllSubjects(int currentPage, int pageSize)
        {
            var result = await _subjectsService.GetAllSubjects(currentPage, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Get subject by id
        /// </summary>
        [HttpGet("subject/{id}")]
        public async Task<ActionResult> GetSubjectById(int id)
        {
            var result = await _subjectsService.GetSubjectById(id);
            return Ok(result);
        }


        /// <summary>
        /// Add new subject
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddSubject(AddSubjectDto dto)
        {
            var result = await _subjectsService.AddSubject(dto);
            if (result == 0) return BadRequest("Failed to add subject");
            return Ok();
        }

        /// <summary>
        /// Add mentor to subject
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/addMentor/{mentorId}")]
        public async Task<ActionResult> UpdateSubjectAddMentor(int subjectId, int mentorId)
        {
            var result = await _subjectsService.AddMentorToSubject(subjectId, mentorId);
            if (result) return Ok();
            return BadRequest("Failed to add mentor to subject");
        }

        /// <summary>
        /// Update subject
        /// </summary>
        [HttpPut("updateSubject/{id}")]
        public async Task<ActionResult> UpdateSubject(int id, AddSubjectDto dto)
        {
            var result = await _subjectsService.UpdateSubject(id, dto);
            if (result) return Ok();
            return BadRequest("Failed to update subject");
        }

        /// <summary>
        /// Remove recommended study resourse
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/removeStudyResource/{studyResourseId}")]
        public async Task<ActionResult> RemoveRecommendedStudyResource(int subjectId, int studyResourceId)
        {
            var result = await _subjectsService.RemoveRecommendedStudyResource(subjectId, studyResourceId);
            if (result) return Ok();
            return BadRequest("Failed to remove recommended study resource");
        }

        /// <summary>
        /// Remove mentor
        /// </summary>
        [HttpPut("updateSubject/{subjectId}/removeMentor/{mentorId}")]
        public async Task<ActionResult> RemoveMentorFromSubject(int subjectId, int mentorId)
        {
            var result = await _subjectsService.RemoveMentorFromSubject(subjectId, mentorId);
            if (result) return Ok();
            return BadRequest("Failed to remove mentor from subject");
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
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _subjectsService.DeleteSubject(id);
            if (result) return Ok();
            return BadRequest("Failed to delete subject");
        }
    }
}
