using Data.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	internal class ProjectRepository : IProjectRepository
	{
		private readonly TestTaskDbContext context;
        public ProjectRepository(TestTaskDbContext context)
        {
			this.context = context;
        }
		public async Task<List<ProjectEntity>> GetAllProjectsAsync() =>
			await context.Projects.ToListAsync();

		public async Task<ProjectEntity> GetProjectByIdAsync(int id) =>
			await context.Projects.FirstOrDefaultAsync(x => x.Id == id);

		public async Task<ProjectEntity> GetProjectByNameAsync(string name) =>
			await context.Projects.FirstOrDefaultAsync(x => x.Name == name);

		public async Task InsertProjectAsync(ProjectEntity project)
		{
			await context.Projects.AddAsync(project);
			await context.SaveChangesAsync();
		}

		public async Task UpdateProjectAsync(ProjectEntity project)
		{
			context.Projects.Update(project);
			await context.SaveChangesAsync();
		}
		public async Task DeleteProjectAsync(ProjectEntity project)
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
