using KMaSA.Models.DTO;

namespace BLInterfaces.Interfaces
{
    public interface IMentorService
    {
        Task<int> AddMentor(AddMentorDto dto, int userId);
    }
}
