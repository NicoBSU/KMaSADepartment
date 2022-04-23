using KMaSA.Models.Entities;

namespace BLInterfaces.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(UserEntity user);
    }
}
