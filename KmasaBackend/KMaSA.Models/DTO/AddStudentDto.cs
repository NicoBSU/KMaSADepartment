namespace KMaSA.Models.DTO;

public class AddStudentDto
{
    public int UserId { get; set; }

    public double Rating { get; set; }

    public CourseDto Course { get; set; }
}