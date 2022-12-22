using TestTask.Entities;
using TestTask.Models;

namespace Mapper
{
	public static class ProjectMapper
	{
		public static ProjectEntity ToEntity(this ProjectModel entity)
		{
			return new ProjectEntity
			{
				Name = entity.Name,
				StartDate = entity.StartDate,
				CompletionDate = entity.CompletionDate,
				Status = entity.Status,
				Priority = entity.Priority
			};
		}

		public static ProjectModel ToModel(this ProjectModel model)
		{
			return new ProjectModel
			{
				Name = model.Name,
				StartDate = model.StartDate,
				CompletionDate = model.CompletionDate,
				Status = model.Status,
				Priority = model.Priority
			};
		}
	}
}