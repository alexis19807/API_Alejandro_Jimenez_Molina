using Domain.ScoreWeigths;
using Serilog;

namespace Infrastructure.Persistence.Repositories
{
	public class ScoreWeigthRepository : IScoreWeigthRepository
	{
		private readonly ApplicationDbContext _context;

		public ScoreWeigthRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddWeigthsAsync(ScoreWeigth scoreWeigth)
		{
			try
			{
				if (_context.ScoreWeigth.Where(s => s.SportManId == scoreWeigth.SportManId).Count() >= 3)
				{
					return;
				}

				await _context.ScoreWeigth.AddAsync(scoreWeigth);

			}
			catch (Exception e)
			{
				Log.Error($"Error adding weigths to the database - {e.Message}");
			}
		}
	}
}
