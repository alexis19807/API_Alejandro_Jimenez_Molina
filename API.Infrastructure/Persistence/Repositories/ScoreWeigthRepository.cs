using Domain.ScoreWeigths;

namespace Infrastructure.Persistence.Repositories
{
	public class ScoreWeigthRepository : IScoreWeigthRepository
	{
		private readonly ApplicationDbContext _context;

		public ScoreWeigthRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddWeigthsAsync(ScoreWeigth scoreWeigth) => await _context.ScoreWeigth.AddAsync(scoreWeigth);
	}
}
