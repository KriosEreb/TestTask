using TestTask.Model;
using TestTask.Data;
using TestTask.Data.Interface;

namespace TestTask.Services
{
	public class ProjectService
	{
		private readonly IProjectRepository projectRepository;
        public ProjectService(ProjectRepository projectRepository)
        {
			this.projectRepository = projectRepository;
        }
        public async bool IsExist(this ProjectModel project)=>
			await projectRepository.GetProjectByNameAsync(project.Name) is ProjectModel project
			? true : false;
	}
}
