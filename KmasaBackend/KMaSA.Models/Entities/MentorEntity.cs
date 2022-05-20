namespace KMaSA.Models.Entities;

public class MentorEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public UserEntity User { get; set; }

    public string Title { get; set; }

    public string? Biography { get; set; }

    public ICollection<CourseWorkEntity> CourseWorks { get; set; }

    public ICollection<SubjectEntity> Subjects { get; set; }

    public ICollection<StudyResourceEntity> Publications { get; set; }
}