using Akvelon.Data.Entities;
using Akvelon.Domain.Models;
using Akvelon.Domain.Models.Requests;
using Akvelon.Domain.Models.Responses;
using Akvelon.Domain.Repository;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akvelon.WebApi.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProjectController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects([FromQuery] QueryParameters query) 
        {
            var projects = await _repository.GetProjectsAsync(query);
            return Ok(_mapper.Map<IEnumerable<GetProjectResponse>>(projects));
        }

        [HttpGet("{projectId}", Name = "GetProject")]
        public async Task<IActionResult> GetProject(Guid projectId)
        {
            var project = await _repository.GetProjectAsync(projectId);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetProjectResponse>(project));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectRequest request)
        {
            Project project;
            try
            {
                project = _mapper.Map<Project>(request);
            }
            catch(AutoMapperMappingException ex)
            {
                return BadRequest($"{ex.MemberMap} is not valid");
            }
            var newProject = await _repository.AddProjectAsync(project);

            return CreatedAtRoute("GetProject",
                new { projectId = newProject.Id },
                _mapper.Map<GetProjectResponse>(newProject));
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(Guid projectId, ProjectRequest request)
        {
            var project = await _repository.GetProjectAsync(projectId);

            if (project == null)
            {
                return await CreateProject(request);
            }

            _mapper.Map(request, project);
            await _repository.UpdateProjectAsync(project);
            
            return Ok(_mapper.Map<GetProjectResponse>(project));
        }

        [HttpPatch("{projectId}")]
        public async Task<IActionResult> PartiacllyUpdateProject(Guid projectId,
            JsonPatchDocument<ProjectRequest> request)
        {
            var project = await _repository.GetProjectAsync(projectId);

            if (project == null)
            {
                var projectRequest = new ProjectRequest();
                request.ApplyTo(projectRequest);

                if (!TryValidateModel(projectRequest))
                {
                    return ValidationProblem(ModelState);
                }

                return await CreateProject(projectRequest);
            }

            var projectToPatch = _mapper.Map<ProjectRequest>(project);
            request.ApplyTo(projectToPatch);

            if (!TryValidateModel(projectToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(projectToPatch, project);

            await _repository.UpdateProjectAsync(project);

            return Ok(_mapper.Map<GetProjectResponse>(project));
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(Guid projectId)
        {
            var project = await _repository.GetProjectAsync(projectId);

            if (project == null)
            {
                return NotFound();
            }

            await _repository.DeleteProjectAsync(project);

            return NoContent();
        }
    }
}
