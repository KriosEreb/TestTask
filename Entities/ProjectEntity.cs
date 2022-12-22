using Enums;

namespace Entities
{
	public class ProjectEntity
	{
		public int Id { get; set; }
		public string Name { get; set; } = String.Empty;
		public DateOnly StartDate { get; set; }
		public DateOnly CompletionDate { get; set; }
		public ProjectStatus Status { get; set; }
		public int Priority { get; set; }
	}
}
