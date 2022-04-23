using KMaSA.Infrastructure.EF;
using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, 
            IConfiguration config){
            
            services.AddIdentityCore<UserEntity>(opt => {
                opt.Password.RequireNonAlphanumeric = false;
            })
               .AddRoles<RoleEntity>()
               .AddRoleManager<RoleManager<RoleEntity>>()
               .AddSignInManager<SignInManager<UserEntity>>()
               .AddRoleValidator<RoleValidator<RoleEntity>>()
               .AddEntityFrameworkStores<KmasaContext>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>{
            //        options.TokenValidationParameters = new TokenValidationParameters{
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };

            //        options.Events = new JwtBearerEvents{
            //            OnMessageReceived = context => {
            //                var accessToken = context.Request.Query["access_token"];
            //                var path = context.HttpContext.Request.Path;
            //                if(!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs")){
            //                    context.Token = accessToken;
            //                }
            //                return Task.CompletedTask;
            //            }
            //        };
            //    }
            //);

            //services.AddAuthorization(opt => {
            //    opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            //    opt.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin","Moderator"));
            //});

            return services;
        }
    }
}
