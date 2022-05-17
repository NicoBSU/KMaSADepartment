namespace KMaSA.Models.DTO.Mentors
{
    public class GetMentorDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public string Title { get; set; }

        public string? Biography { get; set; }

        public ICollection<CourseWorkDto> CourseWorks { get; set; }

        public ICollection<SubjectDto> Subjects { get; set; }

        public ICollection<StudyResourceDto> Publications { get; set; }
    }
}
