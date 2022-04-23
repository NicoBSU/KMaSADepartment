using KMaSA.Models.Enums;

namespace KMaSA.Models.Entities;

public class CourseWorkEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public CourseWorkStatus Status { get; set; }

    public MentorEntity Mentor { get; set; }

    public StudentEntity Student { get; set; }
}