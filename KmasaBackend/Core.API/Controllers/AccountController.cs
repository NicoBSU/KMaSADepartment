using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models.DTO;
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

        public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager,
            ITokenService tokenService, IMapper mapper)
        {

            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Register a user
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<LoginUserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken!");

            var user = _mapper.Map<UserEntity>(registerDto);
            user.UserName = registerDto.UserName.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

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

            return new LoginUserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user)
            };
        }


        /// <summary>
        /// Login a user
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<LoginUserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid username");
            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid password");

            return new LoginUserDto
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
