using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.Subjects;

namespace KMaSA.Models.DTO.StudyResources;

public class GetStudyResourceDto
{
    public string Name { get; set; }

    public string Link { get; set; }

    public ICollection<GetSubjectDto> Subjects { get; set; }

    public ICollection<AddMentorDto> TaggedMentors { get; set; }
}