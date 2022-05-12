using Microsoft.AspNetCore.Identity;

namespace KMaSA.Models.Entities
{
    public class UserRolesEntity : IdentityUserRole<int>
    {
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
