using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_Alejandro_Jimenez_Molina.Extensions
{
	public static class MigrationExtensions
	{
		public static void ApplyMigrations(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();

			var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();
		}
	}
}
