using KMaSA.Models.DTO.CourseWorks;
using KMaSA.Models.DTO.Subjects;

namespace KMaSA.Models.DTO.Students
{
    public class GetStudentDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public double? Rating { get; set; }

        public CourseDto Course { get; set; }

        public GetCourseWorkDto CourseWork { get; set; }

        public ICollection<GetSubjectDto> Subjects { get; set; }
    }
}
