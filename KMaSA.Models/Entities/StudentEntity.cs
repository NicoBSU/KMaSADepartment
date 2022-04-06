namespace KMaSA.Models.Entities;

public class StudentEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public string Email { get; set; }

    public double? Rating { get; set; }

    public CourseEntity Course { get; set; }

    public string? PictureLink { get; set; }

    public CourseWorkEntity CourseWork { get; set; }

    public ICollection<SubjectEntity> Subjects { get; set; }
}