using Microsoft.EntityFrameworkCore;
using Data;

namespace TestTask
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			RegisterServices(builder.Services);

			var app = builder.Build();

			Configure(app);

			app.Run();

			void RegisterServices(IServiceCollection services)
			{

				// Add services to the container.

				builder.Services.AddControllers();
				// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
				builder.Services.AddEndpointsApiExplorer();
				builder.Services.AddSwaggerGen();

				services.AddDbContext<TestTaskDbContext>(options =>
				{
					options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
				});
			}

			void Configure(WebApplication app)
			{
				// Configure the HTTP request pipeline.
				if (app.Environment.IsDevelopment())
				{
					app.UseSwagger();
					app.UseSwaggerUI();
					using var scope = app.Services.CreateScope();
					var db = scope.ServiceProvider.GetRequiredService<TestTaskDbContext>();
					db.Database.EnsureCreated();
				}

				app.UseHttpsRedirection();

				app.UseAuthorization();


				app.MapControllers();
			}
		}
	}
}