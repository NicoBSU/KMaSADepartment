using KMaSA.Models.Enums;

namespace KMaSA.Models.DTO.Account
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public UserDto User { get; set; }

        public UserType UserType { get; set; }

        public AddMentorDto? Mentor { get; set; } = null;

        public AddStudentDto? Student { get; set; } = null;

    }
}