namespace KMaSA.Models.DTO;

public class CourseWorkDto : IDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public CourseWorkStatusDto Status { get; set; }

    public MentorDto Mentor { get; set; }

    public StudentDto Student { get; set; }
}