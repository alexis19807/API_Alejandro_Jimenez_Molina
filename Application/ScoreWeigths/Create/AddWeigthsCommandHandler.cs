using Domain.Primitives;
using Domain.ScoreWeigths;
using Domain.SportMen;
using MediatR;

namespace Application.ScoreWeigths.Create
{
	public class AddWeigthsCommandHandler : IRequestHandler<AddWeigthsCommand, Unit>
	{
		private readonly IScoreWeigthRepository _scoreWeigthRepository;
		private readonly IUnitOfWork _unitOfWork;

		public AddWeigthsCommandHandler(IScoreWeigthRepository scoreWeigthRepository, IUnitOfWork unitOfWork)
		{
			_scoreWeigthRepository = scoreWeigthRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(AddWeigthsCommand command, CancellationToken cancellationToken)
		{
			var weigths = new ScoreWeigth()
			{
				Id = new Guid(),
				Jerk = command.jerk,
				Snatch = command.snatch,
				SportManId = command.sportman
			};

			await this._scoreWeigthRepository.AddWeigthsAsync(weigths);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
