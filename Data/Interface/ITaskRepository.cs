using Entities;

namespace Data.Interface
{
	internal interface ITaskRepository : IDisposable
	{
		Task<List<TaskEntity>> GetAllTasksAsync();
		Task<TaskEntity> GetTaskByIdAsync(int id);
		Task<TaskEntity> GetTaskByNameAsync(string name);
		Task InsertTaskAsync(TaskEntity task);
		Task UpdateTaskAsync(TaskEntity task);
		Task DeleteTaskAsync(TaskEntity task);
	}
}
