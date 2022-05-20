using KMaSA.Models.DTO.Mentors;
using KMaSA.Models.DTO.Students;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;

namespace KMaSA.Models.DTO;

public class UpdateUserDto : IDto
{
    public int Id { get; set; }

    public UpdateStudentDto updateStudentDto { get; set; } = null;

    public UpdateMentorDto updateMentorDto { get; set; } = null;

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string Email { get; set; }

    public string PhotoUrl { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}