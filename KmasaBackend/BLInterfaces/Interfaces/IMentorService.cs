using KMaSA.Models;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.Mentors;

namespace BLInterfaces.Interfaces
{
    public interface IMentorService
    {
        Task<int> AddMentor(AddMentorDto dto, int userId);

        Task<PagedModel<GetMentorDto>> GetAllMentors(int currentPage, int pageSize);

        Task<GetMentorDto> GetMentorById(int id);

        Task<bool> UpdateMentor(int studentId, UpdateMentorDto userDto);
    }
}
