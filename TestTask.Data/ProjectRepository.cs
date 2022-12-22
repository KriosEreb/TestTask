using TestTask.Data.Interface;
using TestTask.Model;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Data
{
	public class ProjectRepository : IProjectRepository
	{
		private readonly TestTaskDbContext context;
        public ProjectRepository(TestTaskDbContext context)
        {
			this.context = context;
        }
		public async Task<List<ProjectModel>> GetAllProjectsAsync() =>
			await context.Projects.ToListAsync();

		public async Task<ProjectModel> GetProjectByIdAsync(int id) =>
			await context.Projects.FirstOrDefaultAsync(x => x.Id == id);

		public async Task<ProjectModel> GetProjectByNameAsync(string name) =>
			await context.Projects.FirstOrDefaultAsync(x => x.Name == name);

		public async Task InsertProjectAsync(ProjectModel project)
		{
			await context.Projects.AddAsync(project);
			await context.SaveChangesAsync();
		}

		public async Task UpdateProjectAsync(ProjectModel project)
		{
			context.Projects.Update(project);
			await context.SaveChangesAsync();
		}
		public async Task DeleteProjectAsync(ProjectModel project)
		{
			context.Projects.Remove(project);
			await context.SaveChangesAsync();
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
