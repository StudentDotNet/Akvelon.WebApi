using Akvelon.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Akvelon.Domain.Repository;
using Akvelon.Domain.Models.Responses;
using AutoMapper;
using System.Collections.Generic;
using Akvelon.Domain.Models.Requests;
using Task = Akvelon.Data.Entities.Task;
using Microsoft.AspNetCore.JsonPatch;

namespace Akvelon.WebApi.Controllers
{
    [ApiController]
    [Route("projects/{projectId}/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TaskController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks(Guid projectId, [FromQuery] QueryParameters query)
        {
            ValidateParameters(projectId);

            var project = await _repository.GetProjectAsync(projectId);
            if (project == null)
            {
                return NotFound();
            }

            var tasks = await _repository.GetTasksAsync(projectId, query);
            return Ok(_mapper.Map<IEnumerable<GetTaskResponse>>(tasks));
        }

        [HttpGet("{taskId}", Name = "GetTask")]
        public async Task<IActionResult> GetTask(Guid projectId, Guid taskId)
        {
            ValidateParameters(projectId);
            ValidateParameters(taskId);

            var task = await _repository.GetTaskAsync(projectId, taskId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTaskResponse>(task));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(Guid projectId, TaskRequest request)
        {
            ValidateParameters(projectId);

            var project = await _repository.GetProjectAsync(projectId);
            if (project == null)
            {
                return BadRequest();
            }

            Task task;
            try
            {
                task = _mapper.Map<Task>(request);
            }
            catch(AutoMapperMappingException ex)
            {
                return BadRequest($"{ex.MemberMap} is not valid");
            }

            var newTask = await _repository.AddTaskAsync(projectId, task);

            return CreatedAtRoute("GetTask",
                new { projectId = projectId, taskId = newTask.Id },
                _mapper.Map<GetTaskResponse>(task));
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(Guid projectId, Guid taskId, TaskRequest request)
        {
            var project = await _repository.GetProjectAsync(projectId);

            if (project == null)
            {
                return BadRequest();
            }

            var task = await _repository.GetTaskAsync(projectId, taskId);

            if (task == null)
            {
                return await CreateTask(projectId, request);
            }

            _mapper.Map(request, task);

            await _repository.UpdateTaskAsync(projectId, taskId, task);

            return Ok(_mapper.Map<GetTaskResponse>(task));
        }

        [HttpPatch("{taskId}")]
        public async Task<IActionResult> PartiacllyUpdateTask(Guid projectId, Guid taskId, 
            JsonPatchDocument<TaskRequest> request)
        {
            var project = await _repository.GetProjectAsync(projectId);

            if (project == null)
            {
                return BadRequest();
            }

            var task = await _repository.GetTaskAsync(projectId, taskId);

            if (task == null)
            {
                var taskRequest = new TaskRequest();
                request.ApplyTo(taskRequest);

                if (!TryValidateModel(taskRequest))
                {
                    return ValidationProblem(ModelState);
                }

                return await CreateTask(projectId, taskRequest);
            }
            var taskToParch = _mapper.Map<TaskRequest>(task);
            request.ApplyTo(taskToParch);

            if (!TryValidateModel(taskToParch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(taskToParch, task);

            await _repository.UpdateTaskAsync(projectId, taskId, task);

            return Ok(_mapper.Map<GetTaskResponse>(task));
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(Guid projectId, Guid taskId)
        {
            var task = await _repository.GetTaskAsync(projectId, taskId);

            if (task == null)
            {
                return NotFound();
            }

            await _repository.DeleteTaskAsync(task);

            return NoContent();
        }

        private void ValidateParameters(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }
        }
    }
}
