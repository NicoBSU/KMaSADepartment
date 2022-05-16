using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace KMaSA.Infrastructure
{
    public class Seed
    {
        public static async Task SeedDb(UserManager<UserEntity> userManager,
            RoleManager<RoleEntity> roleManager)
        {
            var roles = new List<RoleEntity>{
                new RoleEntity{
                    Name = "Mentor"
                },
                new RoleEntity{
                    Name = "Admin"
                },
                new RoleEntity{
                    Name = "Student"
                },
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            //populate admin
            var admin = new UserEntity
            {
                UserName = "admin"
            };
            await userManager.CreateAsync(admin, "Passw0rd");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
