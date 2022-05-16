using KMaSA.Models.DTO.Account;

namespace BLInterfaces.Interfaces
{
    public interface IMentorService
    {
        Task<int> AddMentor(AddMentorDto dto, int userId);
    }
}
