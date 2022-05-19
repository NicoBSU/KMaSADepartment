using KMaSA.Models.DTO.Account;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;

namespace BLInterfaces.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUser(RegisterDto dto);
    }
}