namespace KMaSA.Models.DTO.Students
{
    public class GetStudentDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public double? Rating { get; set; }

        public CourseDto Course { get; set; }

        public CourseWorkDto CourseWork { get; set; }

        public ICollection<SubjectDto> Subjects { get; set; }
    }
}
