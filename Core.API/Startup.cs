using Core.API.Extensions;
using KMaSA.Infrastructure.EF;
using KMaSA.Models.Entities;
using MediatR;
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
                options => options.UseSqlServer(_config.GetConnectionString("KmasaDbConnection")));

            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<KmasaContext>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddIdentityServices(_config);
            services.AddSwaggerGen();
            services.AddCors();
            services.AddMediatR(typeof(Startup));
            
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
