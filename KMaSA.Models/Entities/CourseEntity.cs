namespace KMaSA.Models.Entities;

public class CourseEntity
{
    public int Id { get; set; }

    public CourseNameEntity Number { get; set; }

    public ICollection<StudentEntity> Students { get; set; }
}