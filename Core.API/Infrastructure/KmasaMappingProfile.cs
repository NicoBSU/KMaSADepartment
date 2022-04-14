using AutoMapper;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;

namespace Core.API.Infrastructure;

public sealed class KmasaMappingProfile : Profile
{
    public KmasaMappingProfile()
    {
        this.CreateMap<MentorDto, MentorEntity>().ReverseMap();
    }
}