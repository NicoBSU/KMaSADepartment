using AutoMapper;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.Account;
using KMaSA.Models.DTO.BlogArticles;
using KMaSA.Models.DTO.CourseWorks;
using KMaSA.Models.DTO.Mentors;
using KMaSA.Models.DTO.Students;
using KMaSA.Models.DTO.StudyResources;
using KMaSA.Models.DTO.Subjects;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;

namespace Core.API.Infrastructure;

public sealed class KmasaMappingProfile : Profile
{
    public KmasaMappingProfile()
    {
        this.CreateMap<RegisterDto, UserEntity>();

        //mentor
        this.CreateMap<AddMentorDto, MentorEntity>().ReverseMap();
        this.CreateMap<GetMentorDto, MentorEntity>().ReverseMap();

        //student
        this.CreateMap<AddStudentDto, StudentEntity>().ReverseMap();
        this.CreateMap<GetStudentDto, StudentEntity>().ReverseMap();

        //blog article
        this.CreateMap<AddBlogArticleDto, BlogArticleEntity>().ReverseMap();
        this.CreateMap<GetBlogArticleDto, BlogArticleEntity>().ReverseMap();

        this.CreateMap<CourseDto, CourseEntity>().ReverseMap();
        this.CreateMap<UserDto, UserEntity>().ReverseMap();

        //study resource
        this.CreateMap<GetStudyResourceDto, StudyResourceEntity>().ReverseMap();
        this.CreateMap<AddStudyResourceDto, StudyResourceEntity>().ReverseMap();

        //subjects
        this.CreateMap<GetSubjectDto, SubjectEntity>().ReverseMap();
        this.CreateMap<AddSubjectDto, SubjectEntity>().ReverseMap();

        //photos
        this.CreateMap<PhotoDto, PhotoEntity>().ReverseMap();


        //courseWorks maps
        this.CreateMap<GetCourseWorkDto, CourseWorkEntity>()
            .ForMember(cwe => cwe.Status,
                expression => expression.MapFrom(dto => (CourseWorkStatus)(int)dto.Status));
        this.CreateMap<CourseWorkEntity, GetCourseWorkDto>()
            .ForMember(dto => dto.Status,
                expression => expression.MapFrom(e => (CourseWorkStatus)(int)e.Status));

        this.CreateMap<AddCourseWorkDto, CourseWorkEntity>().ReverseMap();


        this.CreateMap<CourseDto, CourseEntity>().ForMember(ce => ce.Number,
            expression => expression.MapFrom(dto => (CourseName)(byte)dto.Number));
        this.CreateMap<CourseEntity, CourseDto>().ForMember(dto => dto.Number,
            expression => expression.MapFrom(e => (CourseName)(byte)e.Number));
    }
}