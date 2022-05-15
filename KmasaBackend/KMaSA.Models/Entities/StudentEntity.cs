namespace KMaSA.Models.Entities;

public class StudentEntity
{
    public int Id { get; set; }

    public UserEntity User { get; set; }

    public double? Rating { get; set; }

    public CourseEntity Course { get; set; }

    public CourseWorkEntity CourseWork { get; set; }

    public ICollection<SubjectEntity> Subjects { get; set; }
}