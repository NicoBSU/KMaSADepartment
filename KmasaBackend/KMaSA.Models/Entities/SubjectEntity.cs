namespace KMaSA.Models.Entities;

public class SubjectEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string? PictureLink { get; set; }

    public ICollection<MentorEntity> Mentors { get; set; }

    public ICollection<StudyResourceEntity> Literature { get; set; }
}