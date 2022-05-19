using KMaSA.Models.DTO.CourseWorks;

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

        public ICollection<SubjectDto> Subjects { get; set; }
    }
}
