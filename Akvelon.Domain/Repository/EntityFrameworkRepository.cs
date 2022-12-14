using Akvelon.Data;
using Akvelon.Data.Entities;
using Akvelon.Domain.Extension;
using Akvelon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Akvelon.Data.Entities.Task;

namespace Akvelon.Domain.Repository
{
    public class EntityFrameworkRepository : IRepository
    {
        private readonly AppDbContext _context;

        public EntityFrameworkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync(QueryParameters query)
        {
            ValidateParameters(query);

            var collection = _context.Projects as IQueryable<Project>;

            if (!string.IsNullOrWhiteSpace(query.SearchQuery))
            {
                var searchQuery = query.SearchQuery.Trim();
                collection = collection.Where(p => p.Name.Contains(searchQuery));
            }

            if (query.Status != null)
            {
                collection = collection.Where(p => p.Status.Equals(query.Status));
            }

            if (!string.IsNullOrWhiteSpace(query.OrderBy))
            {
                collection = collection.ApplySort(query.OrderBy);
            }

            return await collection.ToListAsync();
        }

        public async Task<Project> GetProjectAsync(Guid projectId)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id.Equals(projectId));
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            project.Id = Guid.NewGuid();

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Task>> GetTasksAsync(Guid projectId, QueryParameters query)
        {
            ValidateParameters(query);

            var collection = _context.Tasks as IQueryable<Task>;
            collection = collection.Where(t => t.ProjectId == projectId);

            if (!string.IsNullOrWhiteSpace(query.SearchQuery))
            {
                var searchQuery = query.SearchQuery.Trim();
                collection = collection.Where(p => p.Name.Contains(searchQuery) 
                                                || p.Description.Contains(searchQuery));
            }

            if (query.TaskStatus != null)
            {
                collection = collection.Where(p => p.Status.Equals(query.TaskStatus));
            }

            if (!string.IsNullOrWhiteSpace(query.OrderBy))
            {
                collection = collection.ApplySort(query.OrderBy);
            }

            return await collection.ToListAsync();
        }

        public async Task<Task> GetTaskAsync(Guid projectId, Guid taskId)
        {
            return await _context.Tasks
                .Where(t => t.Id.Equals(taskId) && t.ProjectId.Equals(projectId))
                .FirstOrDefaultAsync();
        }

        public async Task<Task> AddTaskAsync(Guid projectId, Task task)
        {
            task.Id = Guid.NewGuid();
            task.ProjectId = projectId;

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateTaskAsync(Guid projectId, Guid taskId, Task task)
        {
            task.Id = taskId;
            task.ProjectId = projectId;

            _context.Tasks.Update(task);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTaskAsync(Task task)
        {
            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }

        private void ValidateParameters<T>(T parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
        }
    }
}
