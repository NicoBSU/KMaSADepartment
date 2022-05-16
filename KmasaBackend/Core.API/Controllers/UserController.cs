//using AutoMapper;
//using BLInterfaces.Interfaces;
//using DAInterfaces.Repositories;
//using KMaSA.Models.DTO;
//using KMaSA.Models.Entities;
//using KMaSA.Models.Enums;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Core.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IMapper _mapper;
//        private readonly IPhotoService _photoService;
//        private readonly IUserRepository _userRepository;

//        public UserController(IMapper mapper,
//            IPhotoService photoService,
//            IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//            _mapper = mapper;
//            _photoService = photoService;
//        }

//        / <summary>
//        / Register a user
//        / </summary>
//        [Authorize]
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
//        {
//            userParams.CurrentUsername = User.GetUsername();
//            var users = await _userRepository.GetUsersAsync(userParams);

//            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount
//                , users.TotalPages);
//            return Ok(users);
//        }

//        [Authorize(Roles = "Member")]
//        [HttpGet("{username}", Name = "GetUser")]
//        public async Task<ActionResult<MemberDto>> GetUser(string username)
//        {
//            return await _unitOfWork.UserRepository.GetMemberAsync(username);
//        }

//        [HttpPut]
//        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
//        {
//            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
//            _mapper.Map(memberUpdateDto, user);
//            _unitOfWork.UserRepository.Update(user);

//            if (await _unitOfWork.Complete()) return NoContent();

//            return BadRequest("Failed to update user");

//        }

//        [HttpPost("add-photo")]
//        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
//        {
//            var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());
//            var result = await _photoService.AddPhotoAsync(file);

//            if (result.Error != null) return BadRequest(result.Error.Message);

//            var photo = new PhotoEntity
//            {
//                Url = result.SecureUrl.AbsoluteUri,
//                PublicId = result.PublicId
//            };

//            user.Photos.Add(photo);

//            if (await _unitOfWork.Complete())
//            {
//                return CreatedAtRoute("GetUser", new { username = user.UserName }, _mapper.Map<PhotoDto>(photo));
//            }


//            return BadRequest("Problem adding photo");
//        }

//        [HttpDelete("delete-photo/{photoId}")]
//        public async Task<ActionResult> DeletePhoto(int photoId)
//        {
//            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
//            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

//            if (photo == null) return NotFound();
//            if (photo.IsMain) return BadRequest("You cannot delete your main photo");
//            if (photo.PublicId != null)
//            {
//                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
//                if (result.Error != null) return BadRequest(result.Error.Message);
//            }
//            user.Photos.Remove(photo);
//            if (await _unitOfWork.Complete()) return Ok();
//            return BadRequest("Failed to delete the photo");
//        }
//    }
//}
