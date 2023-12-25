using Domain.SportMen;
using MediatR;

namespace Application.Sportman.GetAll
{
	public class GetSportMenQueryHandler : IRequestHandler<GetSportMenQuery, ICollection<GetSportManQueryResponse>>
	{
		private readonly ISportManRepository _sportManRepository;

		public GetSportMenQueryHandler(ISportManRepository sportManRepository)
		{
			_sportManRepository = sportManRepository;
		}

		//Using MediatR get each sportman with the best score of each category
		public async Task<ICollection<GetSportManQueryResponse>> Handle(GetSportMenQuery query, CancellationToken cancellationToken)
		{
			var sportmen = new List<GetSportManQueryResponse>();

			var result = await this._sportManRepository.GetAll();

			foreach (var item in result)
			{
				sportmen.Add(new GetSportManQueryResponse()
				{
					Id = item.Id,
					Country = item.Country,
					Name = item.Name,
					Snatch = item.ScoreWeigths.FirstOrDefault().Snatch,
					Jerk = item.ScoreWeigths.FirstOrDefault().Jerk
				});
			}

			return sportmen;
		}
	}
}
