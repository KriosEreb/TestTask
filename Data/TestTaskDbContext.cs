using Microsoft.EntityFrameworkCore;
using Entities;
using Enums;

namespace Data
{
	public class TestTaskDbContext : DbContext
	{
		public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options) { }
		public DbSet<ProjectEntity> Projects { get; set; }
		public DbSet<TaskEntity> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProjectEntity>().HasData(new ProjectEntity
			{
				Id = 1,
				Name = "test name",
				StartDate = new DateOnly(2000, 1, 7),
				CompletionDate = new DateOnly(2001, 5, 21),
				Status = ProjectStatus.Active,
				Priority = 4
			});

			modelBuilder.Entity<TaskEntity>().HasData(new TaskEntity
			{
				Id = 1,
				Name = "test task name",
				Status = Enums.TaskStatus.Done,
				Discription = "Test discription",
				Priority = 3,
				ProjectId = 1
			});
		}
	}
}
