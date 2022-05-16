namespace KMaSA.Models.DTO.Account;

public class AddStudentDto
{
    public int UserId { get; set; }

    public double Rating { get; set; }

    public CourseDto Course { get; set; }
}