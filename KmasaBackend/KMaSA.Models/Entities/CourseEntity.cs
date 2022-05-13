using KMaSA.Models.Enums;

namespace KMaSA.Models.Entities;

public class CourseEntity
{
    public int Id { get; set; }

    public CourseName Number { get; set; }

    public ICollection<StudentEntity> Students { get; set; }
}