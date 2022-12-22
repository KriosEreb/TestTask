using Enums;

namespace Entities
{
	public class TaskEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;
		public Enums.TaskStatus Status { get; set; }
		public string Discription { get; set; } = String.Empty;
		public int Priority { get; set; }
		public int ProjectId { get; set; }
	}
}
