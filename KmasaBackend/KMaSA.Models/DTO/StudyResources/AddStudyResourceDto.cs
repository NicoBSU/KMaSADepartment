using KMaSA.Models.DTO.Account;

namespace KMaSA.Models.DTO.StudyResources;

public class AddStudyResourceDto : IDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Link { get; set; }

    public ICollection<SubjectDto> Subjects { get; set; }

    public ICollection<AddMentorDto> TaggedMentors { get; set; }
}