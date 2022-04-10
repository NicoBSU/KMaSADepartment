namespace KMaSA.Models.DTO;

public class CourseDto : IDto
{
    public int Id { get; set; }

    public CourseNameDto Number { get; set; }

    public ICollection<StudentDto> Students { get; set; }
}