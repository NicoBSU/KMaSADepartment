using KMaSA.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace KMaSA.Models.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public UserType UserType { get; set; }
        public MentorEntity Mentor { get; set; } = null;
        public StudentEntity Student { get; set; } = null;
        public PhotoEntity? Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<UserRolesEntity> UserRoles { get; set; }
    }
}
