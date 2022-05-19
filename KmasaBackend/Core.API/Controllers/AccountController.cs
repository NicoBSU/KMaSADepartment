using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;
using Microsoft.AspNetCore.Authorization;
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

            registerDto.User.UserType = UserType.Student;

            var user = await _userService.AddUser(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "Student");

            if (!roleResult.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new LoginSuccessDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user),
                UserRole = user?.UserRoles?.First()?.Role?.Name ?? "Student",
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
                Token = await _tokenService.CreateTokenAsync(user),
                UserRole = user?.UserRoles?.First()?.Role?.Name ?? "Student",
            };
        }

        [HttpPost("{userId}/approveMentor")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ApproveMentor(int userId, AddMentorDto mentor)
        {
            var user = await this.GetUser(userId);

            if (user is null)
            {
                return this.BadRequest("User doesn't exist.");
            }

            user.UserType = UserType.Student;
            var updateStatusResult = await this._userManager.UpdateAsync(user);

            if (!updateStatusResult.Succeeded)
            {
                return this.BadRequest();
            }

            var removeRoleResult = await this._userManager.RemoveFromRoleAsync(user, "Student");

            if (!removeRoleResult.Succeeded)
            {
                return this.BadRequest();
            }

            var roleResult = await this._userManager.AddToRoleAsync(user, "Mentor");

            if (!roleResult.Succeeded)
            {
                return this.BadRequest();
            }

            var result = await this._mentorService.AddMentor(mentor, userId);

            return this.Ok(result);
        }

        [HttpPost("{userId}/approveStudent")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ApproveStudent(int userId, AddStudentDto student)
        {
            var user = await this.GetUser(userId);

            if (user is null)
            {
                return this.BadRequest("User doesn't exist.");
            }

            var result = await this._studentService.AddStudent(student, userId);

            return this.Ok(result);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        private async Task<UserEntity> GetUser(int id)
        {
            return await this._userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}