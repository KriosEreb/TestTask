using TestTask.Data.Interface;
using TestTask.Model;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Data
{
	internal class TaskRepository : ITaskRepository
	{
		private readonly TestTaskDbContext context;
		public TaskRepository(TestTaskDbContext context)
		{
			this.context = context;
		}

		public async Task<List<TaskModel>> GetAllTasksAsync() =>
			await context.Tasks.ToListAsync();

		public async Task<TaskModel> GetTaskByIdAsync(int id) =>
			await context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

		public async Task<TaskModel> GetTaskByNameAsync(string name) =>
			await context.Tasks.FirstOrDefaultAsync(x => x.Name == name);

		public async Task InsertTaskAsync(TaskModel task)
		{
			await context.Tasks.AddAsync(task);
			await context.SaveChangesAsync();
		}

		public async Task UpdateTaskAsync(TaskModel task)
		{
			context.Tasks.Update(task);
			await context.SaveChangesAsync();
		}

		public async Task DeleteTaskAsync(TaskModel task)
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
