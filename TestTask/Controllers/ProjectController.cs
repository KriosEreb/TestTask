using TestTask.Data.Interface;
using TestTask.Entities;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Mappers;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class ProjectController : ControllerBase
    {
        private readonly IProjectRepository projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IResult> GetAll() =>
            Results.Ok(await projectRepository.GetAllProjectsAsync());

        [HttpGet("{projectId:int}")]
        public async Task<IResult> Get(int projectId) =>
		    await projectRepository.GetProjectByIdAsync(projectId) is ProjectEntity project
			? Results.Ok(project)
			: Results.NotFound("Project not found");

        [HttpGet("{userName}")]
        public async Task<IResult> Get(string projectName) =>
            await projectRepository.GetProjectByNameAsync(projectName) is ProjectEntity project
            ? Results.Ok()
            : Results.NotFound("Project not found");

        [HttpPost]
        public async Task<IResult> Post(ProjectModel newProject)
        {
            if(newProject != null)
            {
                var project = newProject.ToEntity();
                await projectRepository.InsertProjectAsync(project);
                return Results.Created<ProjectEntity>("/Projects", project);
            } else {
                return Results.BadRequest();
            }
        }

        [HttpPut]
        public async Task<IResult> Put(ProjectModel updatedProject)
        {
            if(updatedProject != null)
            {
                var project = updatedProject.ToEntity();
                await projectRepository.UpdateProjectAsync(project);
                return Results.Created<ProjectEntity>("/Projects", project);
            } else {
                return Results.NotFound();
            }
        }

        [HttpDelete]
        public async Task<IResult> Delete(int  projectId)
        {

        }

	}
}
