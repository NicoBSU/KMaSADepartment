namespace KMaSA.Models.DTO;

public class StudentDto
{
    public double Rating { get; set; }

    public CourseDto Course { get; set; }

    public CourseWorkDto CourseWork { get; set; }

    public ICollection<SubjectDto> Subjects { get; set; }
}