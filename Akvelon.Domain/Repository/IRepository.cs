using Akvelon.Data.Entities;
using Akvelon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = Akvelon.Data.Entities.Task;

namespace Akvelon.Domain.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync(QueryParameters query);
        Task<Project> GetProjectAsync(Guid projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(Project project);
        Task<IEnumerable<Task>> GetTasksAsync(Guid projectId, QueryParameters query);
        Task<Task> GetTaskAsync(Guid projectId, Guid taskId);
        Task<Task> AddTaskAsync(Guid projectId, Task task);
        Task<bool> UpdateTaskAsync(Guid projectId, Guid taskId, Task task);
        Task<bool> DeleteTaskAsync(Task task);
    }
}
