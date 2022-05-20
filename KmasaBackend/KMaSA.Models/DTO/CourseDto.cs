using KMaSA.Models.Enums;

namespace KMaSA.Models.DTO;

public class CourseDto : IDto
{
    public int Id { get; set; }

    public CourseName Number { get; set; }
}