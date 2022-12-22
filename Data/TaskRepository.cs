using Data.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	internal class TaskRepository : ITaskRepository
	{
		private readonly TestTaskDbContext context;
		public TaskRepository(TestTaskDbContext context)
		{
			this.context = context;
		}

		public async Task<List<TaskEntity>> GetAllTasksAsync() =>
			await context.Tasks.ToListAsync();

		public async Task<TaskEntity> GetTaskByIdAsync(int id) =>
			await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

		public async Task<TaskEntity> GetTaskByNameAsync(string name) =>
			await context.Tasks.FirstOrDefaultAsync(x => x.Name == name);

		public async Task InsertTaskAsync(TaskEntity task)
		{
			await context.Tasks.AddAsync(task);
			await context.SaveChangesAsync();
		}

		public async Task UpdateTaskAsync(TaskEntity task)
		{
			context.Tasks.Update(task);
			await context.SaveChangesAsync();
		}

		public async Task DeleteTaskAsync(TaskEntity task)
		{
			context.Tasks.Remove(task);
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
