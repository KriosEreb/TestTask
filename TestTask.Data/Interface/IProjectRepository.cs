using TestTask.Model;

namespace TestTask.Data.Interface
{
	public interface IProjectRepository : IDisposable
	{
		Task<List<ProjectModel>> GetAllProjectsAsync();
		Task<ProjectModel> GetProjectByIdAsync(int id);
		Task<ProjectModel> GetProjectByNameAsync(string name);
		Task InsertProjectAsync(ProjectModel project);
		Task UpdateProjectAsync(ProjectModel project);
		Task DeleteProjectAsync(ProjectModel project);

	}
}
