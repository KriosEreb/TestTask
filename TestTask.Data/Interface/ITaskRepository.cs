using TestTask.Model;

namespace TestTask.Data.Interface
{
	internal interface ITaskRepository : IDisposable
	{
		Task<List<TaskModel>> GetAllTasksAsync();
		Task<TaskModel> GetTaskByIdAsync(int id);
		Task<TaskModel> GetTaskByNameAsync(string name);
		Task InsertTaskAsync(TaskModel task);
		Task UpdateTaskAsync(TaskModel task);
		Task DeleteTaskAsync(TaskModel task);
	}
}
