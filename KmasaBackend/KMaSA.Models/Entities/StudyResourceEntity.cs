namespace KMaSA.Models.Entities;

public class StudyResourceEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Link { get; set; }

    public ICollection<SubjectEntity> Subjects { get; set; }

    public ICollection<MentorEntity> TaggedMentors { get; set; }
}