using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.StudyResources;

namespace KMaSA.Models.DTO.Subjects;

public class AddSubjectDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string PictureLink { get; set; }

    public ICollection<AddMentorDto> Mentors { get; set; }

    public ICollection<GetStudyResourceDto> Literature { get; set; }
}