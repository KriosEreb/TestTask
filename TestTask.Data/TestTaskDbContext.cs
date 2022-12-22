using Microsoft.EntityFrameworkCore;
using TestTask.Model;
using TestTask.Model.Enums;

namespace TestTask.Data
{
	public class TestTaskDbContext : DbContext
	{
		public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options) { }
		public DbSet<ProjectModel> Projects { get; set; }
		public DbSet<TaskModel> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProjectModel>().HasData(new ProjectModel
			{
				Id = 1,
				Name = "test name",
				StartDate = new DateOnly(2000, 1, 7),
				CompletionDate = new DateOnly(2001, 5, 21),
				Status = ProjectStatus.Active,
				Priority = 4
			});

			modelBuilder.Entity<TaskModel>().HasData(new TaskModel
			{
				Id = 1,
				Name = "test task name",
				Status = TestTask.Model.Enums.TaskStatus.Done,
				Description = "Test description",
				Priority = 3,
				ProjectId = 1
			});
		}
	}
}
