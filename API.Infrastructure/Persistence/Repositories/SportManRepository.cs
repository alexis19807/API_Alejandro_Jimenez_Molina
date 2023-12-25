using Domain.ScoreWeigths;
using Domain.SportMen;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Persistence.Repositories
{
	public class SportManRepository : ISportManRepository
	{
		private readonly ApplicationDbContext _context;

		public SportManRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateSportMan(SportMan sportMan)
		{
			try
			{
				await _context.SportMan.AddAsync(sportMan);
			}
			catch (Exception e)
			{
				Log.Error($"Error creating sportman in the database - {e.Message}");
			}
		}

		public async Task<ICollection<SportMan>> GetAll()
		{
			var query = _context.SportMan
			.Join(
				_context.ScoreWeigth
					.GroupBy(w => w.SportMan.Id)
					.Select(g => new
					{
						SportManId = g.Key,
						MaxSnatch = g.Max(w => w.Snatch),
						MaxJerk = g.Max(w => w.Jerk)
					}),
				sp => sp.Id,
				temp => temp.SportManId,
				(sp, temp) => new SportMan()
				{
					Id = sp.Id,
					Country = sp.Country,
					Name = sp.Name,
					ScoreWeigths = new List<ScoreWeigth>(){
						new ScoreWeigth()
						{
							Snatch = temp.MaxSnatch,
							Jerk = temp.MaxJerk
						}
					}
				}
			);

			return await query.ToListAsync();
		}
	}
}
