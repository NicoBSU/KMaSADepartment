namespace KMaSA.Models.DTO;

public class MentorDto
{
    public string Title { get; set; }

    public string Biography { get; set; }

    public ICollection<CourseWorkDto> CourseWorks { get; set; }

    public ICollection<SubjectDto> Subjects { get; set; }

    public ICollection<StudyResourceDto> Publications { get; set; }

}