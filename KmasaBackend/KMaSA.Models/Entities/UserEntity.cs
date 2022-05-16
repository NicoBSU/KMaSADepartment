using KMaSA.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace KMaSA.Models.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public UserType UserType { get; set; }
        public MentorEntity Mentor { get; set; } = null;
        public StudentEntity Student { get; set; } = null;
        public string? PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<UserRolesEntity> UserRoles { get; set; }
    }
}
