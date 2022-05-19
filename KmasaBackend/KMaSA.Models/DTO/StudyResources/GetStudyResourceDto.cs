using KMaSA.Models.DTO.Account;

namespace KMaSA.Models.DTO.StudyResources;

public class GetStudyResourceDto
{
    public string Name { get; set; }

    public string Link { get; set; }

    public ICollection<SubjectDto> Subjects { get; set; }

    public ICollection<AddMentorDto> TaggedMentors { get; set; }
}