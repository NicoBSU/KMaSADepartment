using AutoMapper;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;
using KMaSA.Models.Enums;

namespace Core.API.Infrastructure;

public sealed class KmasaMappingProfile : Profile
{
    public KmasaMappingProfile()
    {
        this.CreateMap<RegisterDto, UserEntity>();

        this.CreateMap<AddMentorDto, MentorEntity>().ReverseMap();
        this.CreateMap<GetMentorDto, MentorEntity>().ReverseMap();

        this.CreateMap<AddStudentDto, StudentEntity>().ReverseMap();
        this.CreateMap<GetStudentDto, StudentEntity>().ReverseMap();

        this.CreateMap<CourseDto, CourseEntity>().ReverseMap();
        this.CreateMap<UserDto, UserEntity>().ReverseMap();
        this.CreateMap<StudyResourceDto, StudyResourceEntity>().ReverseMap();
        this.CreateMap<SubjectDto, SubjectEntity>().ReverseMap();
        this.CreateMap<PhotoDto, PhotoEntity>().ReverseMap();
        this.CreateMap<CourseWorkDto, CourseWorkEntity>()
            .ForMember(cwe => cwe.Status,
                expression => expression.MapFrom(dto => (CourseWorkStatus)(int)dto.Status));
        this.CreateMap<CourseWorkEntity, CourseWorkDto>()
            .ForMember(dto => dto.Status,
                expression => expression.MapFrom(e => (CourseWorkStatus)(int)e.Status));
        this.CreateMap<CourseDto, CourseEntity>().ForMember(ce => ce.Number,
            expression => expression.MapFrom(dto => (CourseName)(byte)dto.Number));
        this.CreateMap<CourseEntity, CourseDto>().ForMember(dto => dto.Number,
            expression => expression.MapFrom(e => (CourseName)(byte)e.Number));
    }
}