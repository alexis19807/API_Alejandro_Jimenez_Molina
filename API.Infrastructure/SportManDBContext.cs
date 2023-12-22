using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class SportManDBContext : DbContext
	{
		public DbSet<SportMan> SportMan { get; set; }
		public DbSet<ScoreWeigth> ScoreWeigth { get; set; }

		public SportManDBContext(DbContextOptions<SportManDBContext> options)
		: base(options)
		{
		}
	}
}
