using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace KMaSA.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserEntity> AddUser(RegisterDto registerDto, UserType userType)
        {
            var photo = _mapper.Map<PhotoEntity>(registerDto.User.Photo);
            UserEntity user = null;
            user = MapDto(registerDto, photo);
            return user;
        }

        private UserEntity MapDto(RegisterDto registerDto,
            PhotoEntity photo = null)
        {
            var user = new UserEntity()
            {
                UserName = registerDto.UserName.ToLower(),
                Photo = photo,
                FirstName = registerDto.User.FirstName,
                LastName = registerDto.User.LastName,
                MiddleName = registerDto.User.MiddleName,
                Email = registerDto.User.Email,
                DateOfBirth = registerDto.User.DateOfBirth
            };
            return user;
        }
    }
}
