using Entities;

namespace Data.Interface
{
	internal interface IProjectRepository : IDisposable
	{
		Task<List<ProjectEntity>> GetAllProjectsAsync();
		Task<ProjectEntity> GetProjectByIdAsync(int id);
		Task<ProjectEntity> GetProjectByNameAsync(string name);
		Task InsertProjectAsync(ProjectEntity project);
		Task UpdateProjectAsync(ProjectEntity project);
		Task DeleteProjectAsync(ProjectEntity project);

	}
}
