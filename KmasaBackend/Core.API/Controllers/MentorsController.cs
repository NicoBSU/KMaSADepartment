using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.Mentors;
using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMentorService _mentorsService;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;

        public MentorsController(IMentorService mentorsService,
            UserManager<UserEntity> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mentorsService = mentorsService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Mentors
        /// </summary>
        [HttpGet("allMentors")]
        public async Task<ActionResult<PagedModel<GetMentorDto>>> GetAllMentors(int currentPage, int pageSize)
        {
            var mentorsList = await _mentorsService.GetAllMentors(currentPage, pageSize);
            foreach (var item in mentorsList.Items)
            {
                var userEntity = await _userManager.FindByIdAsync(item.UserId.ToString());
                item.User = _mapper.Map<UserDto>(userEntity);
            }
            return mentorsList;
        }

        /// <summary>
        /// Get mentor by id
        /// </summary>
        [HttpGet("mentor/{id}")]
        public async Task<ActionResult<GetMentorDto>> GetMentorById(int id)
        {
            var mentor = await _mentorsService.GetMentorById(id);
            
            var userEntity = await _userManager.FindByIdAsync(mentor.UserId.ToString());
            mentor.User = _mapper.Map<UserDto>(userEntity);
            
            return mentor;
        }

        /// <summary>
        /// Update Mentor
        /// </summary>
        [HttpPut("updateMentor/{id}")]
        public async Task<ActionResult> UpdateMentor(int id, UpdateMentorDto dto)
        {
            var result = await _mentorsService.UpdateMentor(id, dto);
            if (result) return Ok();
            return BadRequest("Failed to update user");
        }
    }
}
