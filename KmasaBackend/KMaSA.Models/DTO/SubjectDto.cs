namespace KMaSA.Models.DTO;

public class SubjectDto : IDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string PictureLink { get; set; }

    public ICollection<AddMentorDto> Mentors { get; set; }

    public ICollection<StudyResourceDto> Literature { get; set; }
}