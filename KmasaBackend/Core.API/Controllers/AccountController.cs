using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly IMentorService _mentorService;

        public AccountController(UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager,
            ITokenService tokenService,
            IMapper mapper,
            IUserService userService,
            IStudentService studentService,
            IMentorService mentorService)
        {

            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userService = userService;
            _mentorService = mentorService;
            _studentService = studentService;
        }

        /// <summary>
        /// Register a user
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<LoginSuccessDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken!");
            if (registerDto.Password != registerDto.ConfirmPassword) return BadRequest("Password and confirm password are not equal!");
            
            UserEntity user = await _userService.AddUser(registerDto, UserType.Mentor);
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            int userId = user.Id;

            if (registerDto.UserType == UserType.Mentor)
            {
                if (registerDto.Mentor is null || registerDto.Student is not null) return BadRequest("Wrong type of user data entered, or correct one is null");
                await _mentorService.AddMentor(registerDto.Mentor, userId);
            }

            if (registerDto.UserType == UserType.Student)
            {
                if (registerDto.Student is null || registerDto.Mentor is not null) return BadRequest("Wrong type of user data entered, or correct one is null");
                await _studentService.AddStudent(registerDto.Student,userId);
            }

            IdentityResult roleResult = null;

            if (registerDto.UserType == UserType.Mentor)
            {
                roleResult = await _userManager.AddToRoleAsync(user, "Mentor");
            }

            if (registerDto.UserType == UserType.Student)
            {
                roleResult = await _userManager.AddToRoleAsync(user, "Student");
            }
            
            if (!(roleResult?.Succeeded) ?? true) return BadRequest(result.Errors);

            return new LoginSuccessDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user)
            };
        }


        /// <summary>
        /// Login a user
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<LoginSuccessDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid username");
            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid password");

            return new LoginSuccessDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
