using KMaSA.Models.Enums;

namespace KMaSA.Models.DTO
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public UserType UserType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}
