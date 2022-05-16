using BLInterfaces.Interfaces;
using Core.API.Extensions;
using Core.API.Infrastructure;
using DAInterfaces.Repositories;
using KMaSA.BusinessLogic.Services;
using KMaSA.Infrastructure.EF;
using KMaSA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KmasaContext>(
                options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddIdentityServices(_config);
            services.AddSwaggerGen();
            services.AddCors();

            services.AddAutoMapper(typeof(KmasaMappingProfile).Assembly);

            //services

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMentorService, MentorService>();

            //repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IMentorsRepository, MentorsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("https://localhost:4200"));

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
