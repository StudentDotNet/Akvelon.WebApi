using Akvelon.Data.Entities;
using Akvelon.Domain.Models.Requests;
using Akvelon.Domain.Models.Responses;
using AutoMapper;

namespace Akvelon.WebApi.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, GetTaskResponse>();
            CreateMap<TaskRequest, Task>();
            CreateMap<Task, TaskRequest>();
        }
    }
}
