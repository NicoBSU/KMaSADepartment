using Microsoft.AspNetCore.Identity;

namespace KMaSA.Models.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<UserRolesEntity> UserRoles { get; set; }
    }
}
