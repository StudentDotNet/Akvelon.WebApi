using Akvelon.Data.Entities;
using Akvelon.Domain.Models.Requests;
using Akvelon.Domain.Models.Responses;
using AutoMapper;
using System;

namespace Akvelon.WebApi.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, GetProjectResponse>()
                .ForMember(
                    dest => dest.StartDate,
                    opt => opt.MapFrom(src => (src.StartDate != null)
                    ? ((DateTime)src.StartDate).ToShortDateString()
                    : null))
                .ForMember(
                    dest => dest.CompletionDate,
                    opt => opt.MapFrom(src => (src.CompletionDate != null)
                    ? ((DateTime)src.CompletionDate).ToShortDateString()
                    : null));

            CreateMap<ProjectRequest, Project>()
                .ForMember(
                    dest => dest.StartDate,
                    opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.StartDate)
                    ? (DateTime?)null
                    : DateTime.Parse(src.StartDate)))
                .ForMember(
                    dest => dest.CompletionDate,
                    opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.CompletionDate)
                    ? (DateTime?)null
                    : DateTime.Parse(src.CompletionDate)));

            CreateMap<Project, ProjectRequest>();
        }
    }
}
