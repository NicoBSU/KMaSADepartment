using KMaSA.Models.DTO.Account;
using KMaSA.Models.Enums;

namespace KMaSA.Models.DTO.CourseWorks;

public class GetCourseWorkDto : IDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public CourseWorkStatus Status { get; set; }

    public AddMentorDto Mentor { get; set; }

    public AddStudentDto Student { get; set; }
}