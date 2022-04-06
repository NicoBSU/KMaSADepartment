namespace KMaSA.Models.Entities;

public class MentorEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public string Email { get; set; }

    public DateTime? BirthDate { get; set; }

    public string Title { get; set; }

    public string? Biography { get; set; }

    public string PictureLink { get; set; }

    public ICollection<CourseWorkEntity> CourseWorks { get; set; }

    public ICollection<SubjectEntity> Subjects { get; set; }

    public ICollection<StudyResourceEntity> Publications { get; set; }
}