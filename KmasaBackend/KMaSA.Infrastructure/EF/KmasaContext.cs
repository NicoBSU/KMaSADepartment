using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KMaSA.Infrastructure.EF;

/// <summary>
/// Represent department application database context.
/// </summary>
public class KmasaContext : IdentityDbContext<UserEntity, RoleEntity, int, IdentityUserClaim<int>,
    UserRolesEntity,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
{
    /// <summary>
    /// Initializes new instance of <see cref="KmasaContext"/>.
    /// </summary>
    /// <param name="options">Db context creation options.</param>
    public KmasaContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<MentorEntity> Mentors { get; set; }

    public DbSet<StudentEntity> Students { get; set; }

    public DbSet<CourseEntity> Courses { get; set; }

    public DbSet<SubjectEntity> Subjects { get; set; }

    public DbSet<StudyResourceEntity> StudyResources { get; set; }

    public DbSet<CourseWorkEntity> CourseWorks { get; set; }

    public DbSet<BlogArticleEntity> Blogs { get; set; }

    public DbSet<PhotoEntity> Photos { get; set; }

    /// <summary>
    /// Configures tables naming conventions.
    /// </summary>
    /// <param name="optionsBuilder">Database options builder.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSnakeCaseNamingConvention();

    /// <summary>
    /// Creates model mapping.
    /// </summary>
    /// <param name="modelBuilder">Database model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        this.ConfigureTableNames(modelBuilder);
        this.ConfigureConstraints(modelBuilder);
        this.BuildRelationShips(modelBuilder);
    }

    private void ConfigureTableNames(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MentorEntity>().ToTable("mentors");
        modelBuilder.Entity<StudentEntity>().ToTable("students");
        modelBuilder.Entity<CourseWorkEntity>().ToTable("courseWorks");
        modelBuilder.Entity<CourseEntity>().ToTable("courses");
        modelBuilder.Entity<SubjectEntity>().ToTable("subjects");
        modelBuilder.Entity<StudyResourceEntity>().ToTable("studyResources");
        modelBuilder.Entity<BlogArticleEntity>().ToTable("blogArticles");
        modelBuilder.Entity<PhotoEntity>().ToTable("photos");
    }

    private void ConfigureConstraints(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().Property(m => m.FirstName).HasMaxLength(32);
        modelBuilder.Entity<UserEntity>().Property(m => m.LastName).HasMaxLength(32);
        modelBuilder.Entity<UserEntity>().Property(m => m.MiddleName).HasMaxLength(32);

        modelBuilder.Entity<MentorEntity>().Property(m => m.Title).HasMaxLength(64);
        modelBuilder.Entity<MentorEntity>().Property(m => m.Biography).HasMaxLength(512);

        modelBuilder.Entity<CourseEntity>().Property(s => s.Number).HasConversion<string>();

        modelBuilder.Entity<CourseWorkEntity>().Property(cw => cw.Title).HasMaxLength(128);
        modelBuilder.Entity<CourseWorkEntity>().Property(c => c.Status).HasConversion<string>();

        modelBuilder.Entity<StudyResourceEntity>().Property(sr => sr.Name).HasMaxLength(128);
        modelBuilder.Entity<StudyResourceEntity>().Property(sr => sr.Link).HasMaxLength(256);

        modelBuilder.Entity<SubjectEntity>().Property(s => s.Title).HasMaxLength(128);
        modelBuilder.Entity<SubjectEntity>().Property(s => s.Description).HasMaxLength(512);
        modelBuilder.Entity<SubjectEntity>().Property(s => s.PictureLink).HasMaxLength(256);

        modelBuilder.Entity<BlogArticleEntity>().Property(ba => ba.Title).HasMaxLength(128);
        modelBuilder.Entity<BlogArticleEntity>().Property(ba => ba.Content).HasMaxLength(1024);
        modelBuilder.Entity<BlogArticleEntity>().Property(ba => ba.PicturesLinks).HasMaxLength(256);
    }

    private void BuildRelationShips(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

        modelBuilder.Entity<RoleEntity>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        modelBuilder.Entity<UserEntity>()
            .HasOne(m => m.Student)
            .WithOne(s => s.User)
            .HasForeignKey<StudentEntity>(m => m.UserId)
            .IsRequired(false);
        modelBuilder.Entity<UserEntity>()
            .HasOne(m => m.Mentor)
            .WithOne(s => s.User)
            .HasForeignKey<MentorEntity>(m => m.UserId)
            .IsRequired(false);
        modelBuilder.Entity<MentorEntity>()
            .HasMany(m => m.CourseWorks)
            .WithOne(cw => cw.Mentor);
        modelBuilder.Entity<StudentEntity>()
            .HasOne(s => s.CourseWork)
            .WithOne(cw => cw.Student)
            .HasForeignKey<CourseWorkEntity>(s => s.StudentId);
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(s => s.Mentors)
            .WithMany(m => m.Subjects);
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(s => s.Mentors)
            .WithMany(m => m.Subjects);
        modelBuilder.Entity<SubjectEntity>()
            .HasMany(s => s.Literature)
            .WithMany(rl => rl.Subjects);
        modelBuilder.Entity<CourseEntity>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Course);
        modelBuilder.Entity<StudyResourceEntity>()
            .HasMany(sr => sr.TaggedMentors)
            .WithMany(m => m.Publications);
    }
}