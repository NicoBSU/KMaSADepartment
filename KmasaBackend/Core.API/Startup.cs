using System.Text.Json.Serialization;
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

            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddEndpointsApiExplorer();
            services.AddIdentityServices(_config);
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddAutoMapper(typeof(KmasaMappingProfile).Assembly);

            //services

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IBlogArticlesService, BlogArticlesService>();
            services.AddScoped<ICourseWorksService, CourseWorksService>();
            services.AddScoped<IStudyResourcesService, StudyResourcesService>();
            services.AddScoped<ISubjectsService, SubjectsService>();

            //repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IMentorsRepository, MentorsRepository>();
            services.AddScoped<IBlogArticlesRepository, BlogArticlesRepository>();
            services.AddScoped<ICourseWorksRepository, CourseWorksRepository>();
            services.AddScoped<IStudyResourcesRepository, StudyResourceRepository>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();
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

            app.UseCors("EnableCORS");
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