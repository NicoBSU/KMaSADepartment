using AutoMapper;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;

namespace Core.API.Infrastructure;

public sealed class KmasaMappingProfile : Profile
{
    public KmasaMappingProfile()
    {
        this.CreateMap<MentorDto, MentorEntity>().ReverseMap();
        this.CreateMap<StudentDto, StudentEntity>().ReverseMap();
        this.CreateMap<CourseDto, CourseEntity>().ReverseMap();
        this.CreateMap<StudyResourceDto, StudyResourceEntity>().ReverseMap();
        this.CreateMap<SubjectDto, SubjectEntity>().ReverseMap();
        this.CreateMap<CourseWorkDto, CourseWorkEntity>()
            .ForMember(cwe => cwe.Status,
                expression => expression.MapFrom(dto => (CourseWorkStatusDto)(int)dto.Status));
        this.CreateMap<CourseWorkEntity, CourseWorkDto>()
            .ForMember(dto => dto.Status,
                expression => expression.MapFrom(e => (CourseWorkStatusEntity)(int)e.Status));
        this.CreateMap<CourseDto, CourseEntity>().ForMember(ce => ce.Number,
            expression => expression.MapFrom(dto => (CourseNameDto)(byte)dto.Number));
        this.CreateMap<CourseEntity, CourseDto>().ForMember(dto => dto.Number,
            expression => expression.MapFrom(e => (CourseNameEntity)(byte)e.Number));
    }
}