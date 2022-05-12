using Microsoft.AspNetCore.Identity;

namespace KMaSA.Models.Entities
{
    public class RoleEntity : IdentityRole<int>
    {
        public ICollection<UserRolesEntity> UserRoles { get; set; }
    }
}
