using KMaSA.Models.DTO.CourseWorks;
using KMaSA.Models.DTO.StudyResources;
using KMaSA.Models.DTO.Subjects;

namespace KMaSA.Models.DTO.Mentors
{
    public class GetMentorDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public string Title { get; set; }

        public string? Biography { get; set; }

        public ICollection<GetCourseWorkDto> CourseWorks { get; set; }

        public ICollection<GetSubjectDto> Subjects { get; set; }

        public ICollection<GetStudyResourceDto> Publications { get; set; }
    }
}
