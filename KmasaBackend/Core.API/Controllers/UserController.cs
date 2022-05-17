using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper,
            IPhotoService photoService,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _photoService = photoService;
        }

        /// <summary>
        /// Add photo
        /// </summary>
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            return Ok(new PhotoDto());
        }

        /// <summary>
        /// Delete photo
        /// </summary>
        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            return Ok();
        }
    }
}
